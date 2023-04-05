import network
import ubinascii
import ujson
import uasyncio as asyncio
from micropython import const


class WIFI:
    def __init__(self):
        self._station = None
        self._ssid = None
        self._password = None

    async def connect_to_wifi(self) -> bool:
        print(f"Connecting WI-FI to {self._ssid}...")
        self._station = network.WLAN(network.STA_IF)
        self._station.active(True)

        if self._station.isconnected():
            print("Already connected to WiFi")
            return False

        self._station.connect(self._ssid, self._password)

        for _ in range(20):
            await asyncio.sleep(1)
            if self._station.isconnected():
                print("Successfully connected to WiFi")
                print(self._station.ifconfig())
                return True

        print("Connection failed")
        return self._station.isconnected()

    async def open_ap(self) -> bool:
        if self.is_connected():
            self.disconnect()

        self._station = network.WLAN(network.AP_IF)
        self._station.active(True)
        mac = ubinascii.hexlify(self._station.config('mac'), ':').decode()
        ssid = f'espbot ({mac})'
        self._station.config(essid=ssid, password=const('123'))

        for _ in range(20):
            await asyncio.sleep(1)
            if self._station.isconnected():
                print(f"AP {ssid} was opened.")
                return True

        print("Open AP failed.")
        return False

    def scan(self):
        if self._station is None:
            return []

        return self._station.scan()

    def disconnect(self):
        if self._station is None:
            return

        self._station.disconnect()

    def is_connected(self) -> bool:
        return self._station.isconnected() if self._station is not None else False

    def save_credentials(self, ssid: str, password: str) -> bool:
        try:
            credentials = {'ssid': ssid, 'password': password}
            with open('wifi_credentials.json', 'w') as f:
                ujson.dump(credentials, f)
            self._ssid = ssid
            self._password = password
            return True
        except:
            return False

    def load_credentials(self) -> bool:
        try:
            with open('wifi_credentials.json', 'r') as config:
                credentials = ujson.load(config)
                self._ssid = credentials['ssid']
                self._password = credentials['password']
            return True

        except:
            return False

    def deinit(self) -> None:
        if self._station is None:
            return

        if self._station.isconnected():
            self._station.disconnect()
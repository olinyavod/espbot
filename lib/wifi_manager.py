import network
import uasyncio as asyncio


class WIFI:
    def __init__(self, ssid: str, password: str):
        self.ssid = ssid
        self.password = password

    async def connect(self) -> bool:
        print(f"Connecting WI-FI to {self.ssid}...")
        station = network.WLAN(network.STA_IF)
        station.active(True)

        if station.isconnected():
            print("Already connected to WiFi")
            return False

        station.connect(self.ssid, self.password)

        while not station.isconnected():
            await asyncio.sleep_ms(500)
            if not station.isconnected():
                print("Connection failed")
                continue

        print("Successfully connected to WiFi")
        print(station.ifconfig())

        return station.isconnected()
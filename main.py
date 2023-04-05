import uasyncio as asyncio
from lib.wifi_manager import WIFI
from micropython import const


async def main():
    wifi = WIFI(const('Extrim'), const('Port!23456'))

    await asyncio.sleep(1)
    await wifi.connect()

if __name__ == '__main__':
    asyncio.run(main())
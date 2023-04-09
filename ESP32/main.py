import uasyncio as asyncio
from lib.wifi_manager import WIFI
from lib.MicroWebSrv.microWebSrv import MicroWebSrv


async def main():
    wifi = WIFI()
    web_server = MicroWebSrv(webPath='www/')
    try:
        await asyncio.sleep(1)

        if wifi.load_credentials():
            await wifi.connect_to_wifi()
        else:
            await wifi.open_ap()

        web_server.Start(threaded=False)

    except:
        wifi.deinit()

if __name__ == '__main__':
    asyncio.run(main())
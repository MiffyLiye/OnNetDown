# OnNetDown

A daemon to run custom command on network disconnected.

## Usage Example
A server (e.g. NAS server) to protect is connected to an uninterruptible power supply (UPS).
The server has wired network connection to a router.
The router is not connected to the UPS.

When mains electricity fails, the router will go down immediately, and the UPS can only provide power for the server for several minutes.

With this OnNetDown daemon, the server can detect the mains electricity failure via the status of the wired network interface, and send command to properly shutdown the server.

## Tech stack
* Language: C#
* Runtime: .NET Framework, Mono

## How To Use

Build.

Copy build results (```OnNetDown.exe```, ```OnNetDown.exe.config```) to somewhere (e.g. ```/root/bin/OnNetDown/*```).

Edit ```OnNetDown.exe.config``` to customize the application settings.

Copy ```on-net-down.service``` to ```/etc/systemd/system/*```

Edit ```on-net-down.service``` to update the application path in ```ExecStart```.

Run ```systemctl start on-net-down.service``` to start the daemon.

Run ```systemctl enable on-net-down.service``` to allow the daemon to start automatically each time the operating system started.

## Development tools
* Visual Studio 2017

## Tested platforms
* openSUSE 42.2

# Cisco Device Info
This is the public repo for Cisco Device Info from http://damn.technology . For installable releases please download and install the software from there.

Cisco Device Info (CDI) is a Windows application to retrieve runtime information from Cisco equipment such as routers and switches.

The software is written in C#, with a VS2013 solution file provided.

## License

GNU Library General Public License (LGPL) version 2.1

## Known Bugs / Issues
- On a 6509 running catos 8.5. the interface id's don't show up under description. it just says "10/100 utp ethernet (cat3/5)".

## Outstanding featutre requests
- LLDP Neighbour information;
- Re-usable SNMP credentials;
- Review masking of comunity strings;

## Version history
### 1.3.0
- Corrected calculation for interface speeds where speed >4GBps;
- Fix bug where interface would be left in a broken state if communication with a device was lost;
- Graph now better handles low-latency connections, with graceful failing;
- Flexible column display (with addition to display IfIndex column)
- Added tooltip to chart series
- Where no data for one tab is available for that device, the tab will be hidden;

### 1.2.0
- Corrected a validation error that prevented SNMP communities using non alphanumeric characters;
- Added the ability to edit devices once added;
- Added the ability to increase the default timeout when connecting to devices;
- Added interface descriptions as an availale column to display;

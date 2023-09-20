# Canetis Radar v3
## Improved UI and added Section Highlighting
This fork is for 7.1 Surround with side Speakers only (Voicemeeter supported), 
It adds functionality such as:

* Sectioned Radar with Highlights
* Highlightduration configurable
* Section Amount configurable
* Minimum Sound Detection Threshold configurable
* Slight delay added to visualisation for better usability
 
<p align="center">
    <img src=/Resources/radar.png>
    <img src=/Resources/screen.png>
</p>
CanetisRadar is open-source application for helping with recognizing sound direction in games. It has overlay that can be used in games and it uses 7.1 audio to calculate sound direction.

## How to use
You need 7.1 audio device to be connected and selected as primary speaker (including side speakers), but don´t worry. You can also use virtual audio device. First of all check if your sound card or headphones does not support it and if they don´t use this guide.

 1. Download [VB-Cable](https://www.vb-audio.com/Cable/) (better alternative: [Raser Surround](https://www.razer.com/surround))
 2. Install it
 3. **Reboot PC**
 4. Go to sound settings 
 5. Open *Playback* tab
 6. Set *CABLE Input* as default
 7. Click on *Configure*
 8. Set sound to *7.1 surround* and enable all speakers
 9. Go to *Recording* tab
 10. Click on CABLE Output and click *Properties*
 11. Go to *Listen* tab
 12. Check *Listen to this device*
 13. Set your normal playback device
 14. Profit
 

## Download
You can download [latest compiled build from AppVeyor](https://ci.appveyor.com/project/SamuelTulach/canetisradar/build/artifacts), [releases](https://github.com/SamuelTulach/CanetisRadar/releases) or build it from source.

## Contributing
If you want to help, you can create pull-request.

You can also **star this repo** or **fork this repo**.

## License

    Copyright (c) 2018 Samuel Tulach
    
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

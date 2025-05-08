# Pantheon Server Time Mod

A mod for Pantheon: Rise of the Fallen that displays the current in-game server time on your UI, positioned intelligently to work seamlessly with or without the server name display mod.

## Features

- **Displays Current Server Time:** Shows the current server time in a clear, visible location on your UI.
- **Smart Positioning:** 
  - If the [ShowServerAndShard](https://github.com/onyxius/ShowServerAndShard) (server name display) mod is present, the time appears directly below the server name.
  - If not, the time appears just below the compass, in the same spot the server name would be.
- **Automatic Updates:** The time display updates every second.
- **Easy to Read:** Uses yellow TextMeshPro text for high visibility.
- **No Configuration Needed:** Works automatically on game launch.

## Installation

### Manual Method

1. **Install MelonLoader** (if you haven't already).
2. **Download** `ShowServerTime.dll` from the [Releases](https://github.com/onyxius/Pantheon-ShowServerTime-Mod/releases) page.
3. **Place** `ShowServerTime.dll` in your game's `Mods` folder:
   ```
   <Pantheon Game Directory>/Mods/
   ```
4. **(Optional)** For best results, also install the [ShowServerAndShard](https://github.com/onyxius/ShowServerAndShard) mod.

### Automatic Method

For easy management and automatic updates of all available Pantheon mods, use the [ModsOfPantheonClient](https://github.com/ModsOfPantheon/ModsOfPantheonClient).

## Usage

- Launch the game.  
- The server time will appear below the compass or below the server name (if that mod is present).
- No configuration or setup is required.

## Compatibility

- **Works with or without the ShowServerAndShard mod.**
- Designed for Pantheon: Rise of the Fallen with MelonLoader.

## Version History

### 1.0.0
- Initial release.
- Displays server time with smart positioning.
- Automatic updates every second.

## Contributing

Pull requests and suggestions are welcome!  
If you find a bug or have a feature request, please open an issue.

## Community & Resources

- [Mods of Pantheon Discord](https://discord.gg/h96Tuk5h) – Get help, share mods, and join the community.
- [ModsOfPantheonClient](https://github.com/ModsOfPantheon/ModsOfPantheonClient) – Tool for downloading and deploying mods.

---

*This mod is not affiliated with or endorsed by Visionary Realms or Pantheon: Rise of the Fallen.*
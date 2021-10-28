# COVIDBoy
This is the repository for Assignment 2 of COMP 376 - Introduction to Game Development Fall 2021 at Concordia University. This assignment is taking inspiration from the 1985 arcade game [Paperboy](https://en.wikipedia.org/wiki/Paperboy_(video_game)) but taking it to the modern context of the COVID-19 pandemic. You are playing a decontaminator, your job is to cleanse the platforms and throw masks at pedestrians to prevent the spread of the virus. This 2D side-scroller platform game is never ending and contains 2 game modes! Beware, you will lose if the virus spreads too much.

## Art

All of the visuals were created by the author using [GIMP](https://www.gimp.org/) and the characters were based on a royalty free sprite template sheet. The reference material is linked at the end of this README.

## Normal Game Mode

- Cleaned platforms give you 2 points
- Missed platforms make you lose 1 point
- You lose if your score gets to -20

## New Game Plus Game Mode

- Cleaned platforms give you 1 point
- Missed platforms make you lose 2 points
- Pressing Q will double your movement speed for 3 seconds, this ability can be activated every 10 seconds
- You lose if your score gets to -20

## Getting Started

To clone and run this application, you'll need [Unity 2020.3.17f1](https://unity3d.com/get-unity/download?thank-you=update&download_nid=65098&os=Win) installed on your computer.

## How To Use This Project

### Controls

Action | Key on keyboard
--- | --- 
Move left | `w`
Move right | `d` 
Jump | `space`
Shoot masks | `left click`
Speed boost (new game plus only) | `q`
Quit game | `escape`

### Prerequisites
 
- [Unity 2020.3.17f1](https://unity3d.com/get-unity/download?thank-you=update&download_nid=65098&os=Win)

## Authors

  - **Antoine Poulin**
    [Dwarf1er](https://github.com/Dwarf1er)

## License

This project is licensed under [The MIT License (MIT)](LICENSE)

## Acknowledgments

  - **Billie Thompson**, this README was based on the template provided [here](https://github.com/PurpleBooth/a-good-readme-template)
  - **Mikkel Paulson**, this project was inspired by the project found [here](https://github.com/MikkelPaulson/smart-health-card-parser)
  - **2D Sprites**, the sprites for the characters in this game were inspired by the royalty free templates you can find [here](https://craftpix.net/freebies/free-3-character-sprite-sheets-pixel-art/)
  - **Patrick de Arteaga**, the soundtrack for this game, Acción (Merodeador Nocturno), was provided royalty free and can be found [here](https://patrickdearteaga.com/)
  - **GameCI**, the build deployment was made with the help of the GameCI documentation found [here](https://github.com/game-ci/documentation)

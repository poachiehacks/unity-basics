Learning the Basics of Unity

Things I've learned to do:
- place a terrain (no hitbox yet)
- place simple 3D shapes
- mess around with the Transform property of a GameObject to edit position and rotation
- accept input from keyboard (WASD or arrow keys) to move a cube's position
- use AD/left-right to rotate cube so that player can turn it
- use Time class to deal with Time in a game
    - Time.deltaTime for time since last frame
    - Time.time for time since application start
- keep an object a set distance away from another object as the other object moves
- keep the object at the same location relative to the other object as the other object moves
- add sinusoidal undulation in the vertical axis using `Mathf` and `Time.time`
- control player with a controller such as a DS4 using a set of Input Actions
- slowly rotate a player's vertical axis to align with the vertical axis

Things I understand now:
- Input Actions vs. Input Manager


Things to do:
- have smooth, continuous joystick input (so NOT like a keyboard)


Learnings:
- Input Actions has better organization:
    - allows you to flexibly assign different functions to the same buttons depending on the context
- Input Actions also allows button combinations for bindings. Don't think Input Manager allows that


Resources consulted:

tips for using git to version control Unity Projects
https://forum.unity.com/threads/unity-not-saving-scenes-or-project-lost-everything-twice.1155164/
https://github.com/github/gitignore/blob/main/Unity.gitignore

Moving a project to another location on disk
https://discussions.unity.com/t/moving-the-project/45147

Difference between `Save` and `Save Project`
https://docs.unity3d.com/Manual/Saving.html

Using Input Actions to implement controller input
https://www.youtube.com/watch?v=p-3S73MaDP8

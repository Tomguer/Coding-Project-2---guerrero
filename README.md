# Coding-Project-2---guerrero

The idea for this game just came from "what is the best way to use the dash system mechanic?" I started by building out a couple of different paths all ending in the center. The propulsion forward was the first mechanic done and so while the right and left dash can be helpful, they aren't as necessary.

The first issue I ran into was putting the damage script on to an object. In order for it to hurt me, I would go straight through. My original fix was to create two objects, one with damage and one without so the player would collide with it. Since I knew there had to be another way I kept looking into it and found that the object needed two box colliders on it. One that is a trigger and one that isn't.

A few of the problems I ran into, I would discover that the only thing wrong is a typo in the code itself. I had gotten the lose screen to work but the win screen wasn't working. After looking back and forth in different unity windows I checked the code, where I found that there was a random letter in front of the win code.


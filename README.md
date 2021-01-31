# Global Game Jam 2021

Hi, I’m Thomas. This is small little FPS with a shotgun, items, and random maps.
WASD to Move, Click to Shoot, Esc to exit the game.
There’s no Art, Sound, Plot, or Production (because I made this by myself). If this is a problem for you, sorry but that’s a you deal.

Right, so the rest of this is basically a GGJ 2021 post-mortem, because I wanted to write one, fight me.

Basically, a few months ago I asked myself “what if DOOM was a roguelike?” To my knowledge, no games have tried to explore such a concept, so I decided to just go ahead and do it myself. Obviously, I can’t fully execute on that idea in only two days by myself, so this project ended up more as a proof of concept than anything else. Does it work? Not really. Is it enjoyable? Again, not really. However, I feel it’s a good exploration of the idea, and was able to make it all by myself, so we take those.

Some key things I learned, should I decide to pick this idea back up in the future:

---MOVEMENT MUST BE SNAPPY---
This is no-brainer, execution-heavy shooters like DOOM need to move well to feel good and be fair. This has always been understood. However, the two things I figured out with this prototype is that acceleration, not speed, is the key to this good movement. Players can’t really notice their speed (unless they can see things that don’t move), but they can always feel acceleration, so good-feeling acceleration increases good move-feel. My guess is that acceleration needs to be large (zero to walk-speed very quickly) and snappy (switching directions should take as much time as starting from a standstill, even though that means the acceleration must be doubled). I’ve also decided that figuring out look-feel is a losing game, because mouse-sensitivity and screen size are unknowable.

---BUILD FOR THE PLAYER’S WEAPONS---
Again, another obvious one (if you know your player-centric design), but one that didn’t really occur to me until now. Specifically, I built a room with only thin pillars in it. Trouble is, the player only has a shotgun. With how the pillars were laid out, about 1/3 of all of the player’s pellets would hit a pillar before reaching an enemy, effectively tripling the health of all the enemies in that room. Enemies, on the other hand, only had single-shot guns, so they didn’t need to worry about pillars blocking all of their shots (it’s also because they have almost-perfect aim but whatever). The takeaway here is that you need to consider the shot profiles and use-cases of the player’s weapons (or whatever general world-interaction mechanic) when building levels and maps, specifically cases where certain geometries invalidate certain weapons (interaction mechanics) by just existing.

---MAP GENERATION SHOULD BE DATA-DRIVEN, NOT GEOMETRY DRIVEN---
In addition to learning that I, in fact, did not know how to spell the word “geometery”, I also learned that Rotation is a Fuck. The one part where I feel I truly missed the mark with this project was the map generator, and it was purely because I couldn’t get the new parts of the map to correctly rotate into place when instantiating them in world space. I tried to amend this by manually rotating rooms and hallways with code, but it never worked. I believe more data-driven, non-geomterey based solutions to this issue (not being able to piece rooms together) exists, I just didn’t pursue it because of time constraints. Don’t blame me, quaternions are hard. Either way, a more robust solution to map-gen than the one I created is necessary to make maps that don’t break half the time.

Oh, and that well-made and diegetic art/sound is important, but hey I’m one dude so chill out.


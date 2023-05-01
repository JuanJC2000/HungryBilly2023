# HungryBilly2023
Mini game jam level with theme of "Repair".

# Release of Build
i have released the .exe and the meta files that come with it on the latest and only release of the repo, as a means to share the actual build. I will also be creating a zip file of the .exe for ease of accessbility. 

The game comes with instructions and how to play, so no need to explain it here.

Overall this was not only fun but my first real application of a game jam. Both my previous attempts i wasnt even close to recreating the simplicty and build that i have here, it really is a sublime feeling. 

Anyways, i have attached and created a design doc that i made before starting the brief. The reason for this is that i tended to lose my focus and overall objective on previous attempts. I have been working hard and diligintley to produce a clean game build, whatever its capabilities.

All the code written for this project was done by me. Everything comes out my hard rock programmer brain. 
My use of a game manager surprised me even, as i was finally able to call functions and conditions outside of 1 class.

The assets used for this project include the following linked below -
https://assetstore.unity.com/packages/3d/environments/roadways/simple-roads-212360 (simple roads asset)

The car is from Unity Learns free assets for prototype testing. 

These are the 2 only assets used. All other functionality is custom made.

Total time in project from commits = 8 hours

# Bugs 

If you are confused about the waypoint system, don't worry, so am I. What
We wanted was a gameplay loop of start -> get to checkpoint -> new checkpoint intansiates. 
However I couldn't get that to work so called our win function when any trigger with waypoint tag would enter it.

The waypoints are represented by a waypoinspawner under Hierachy -> GameManager -> waypoinspawner. In there you can find the relevant scripts as well.


A fix for this is to make another instantiate with a conditional if the trigger does indeed exist. We would then disable our current index gameobject and go on from there.

However think I got inside my head and couldn't pull it off at the end.

Also enjoy flying through the air and traversing this insanely complex maze. Should have used a smaller track. But this is more fun.

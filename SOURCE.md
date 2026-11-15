# SWE 402 – Assignment 3
## Improving Game Feel

### 1. Student Information
- **Student Name:** Zahra Mahdi Aljaroudi
- **Student ID:** [Enter your student ID]
- **Course:** SWE 402 – Game Development
- **Unity Version:** 6000.3.2f1

### 2. Project Overview
This project improves the game feel of the supplied 2D Brick Breaker game by adding visual effects, animations, audio feedback, and interface feedback.

The original gameplay mechanics were preserved. All improvements were implemented in the After scene, while the Before scene remains unchanged for comparison.

### 3. Scenes
- **Before:** `Assets/_Project/Scenes/Before.unity`
- **After:** `Assets/_Project/Scenes/After.unity`

### 4. Game Controls
- Mouse: Move the paddle.
- A / D: Move the paddle.
- Left / Right Arrow Keys: Move the paddle.

The ball launches automatically.

### 5. Intended Game Feel
**Playful and Bouncy**

The goal was to make the game feel more responsive, playful, and satisfying through clear visual and audio feedback without changing the original gameplay mechanics.

### 6. Implemented Improvements

| Improvement | Trigger | Implementation | Purpose |
|---|---|---|---|
| Brick Impact Effect | BrickDestroyed | BrickExplosionFeedback.cs and BrickExplosion Prefab | Displays particles when a brick is destroyed |
| Reactive Animation | BallHitPaddle | PaddleReactionFeedback.cs | Adds squash and stretch animation to the paddle |
| Event-Based Audio | BallHitPaddle, BrickDestroyed, BallLost | GameFeelAudioFeedback.cs | Provides distinct sounds for important game events |
| Interface Feedback | ScoreChanged | ScoreFeedback.cs | Animates the score display when points are added |
| Additional Technique | Ball movement | Trail Renderer | Adds a visual trail behind the ball |

### 7. Audio Assets and Credits

The following audio assets were obtained from Freesound:

1. **BallHit.wav**
   - Author: minerjr
   - Source: https://freesound.org/people/minerjr/sounds/89977/
   - License: Creative Commons Attribution 3.0.
   - Used for: Paddle collision sound.

2. **brick falling on brick.wav**
   - Author: Hankof
   - Source: https://freesound.org/people/Hankof/sounds/655622/
   - License: Creative Commons 0 (CC0).
   - Used for: Brick destruction sound.

3. **lostItem.mp3**
   - Author: Kastenfrosch
   - Source: https://freesound.org/people/Kastenfrosch/sounds/162465/
   - License: Creative Commons 0 (CC0).
   - Used for: Ball loss sound.

### 8. Playtest Observations and Revision

The game was tested by another player using the Before and After versions.

**Observation:**
The player indicated that the collision sound was too loud.

**Revision:**
The audio volume was reduced from 0.7 to 0.5.

**Result:**
The sound level was reduced to provide a more balanced audio experience while keeping the collision feedback noticeable.

### 9. Gameplay Behavior

The original gameplay rules and mechanics were preserved.

When the player loses the final life, the game resets the lives and score according to the starter project's behavior. The board is not rebuilt, as specified in the assignment instructions.

### 10. Video Demonstration

[Insert the accessible 2–3-minute demonstration video link here.]

The video demonstrates:
- Before and After gameplay.
- All five game-feel improvements.
- An explanation of an implemented script or effect.
- Playtest feedback and the resulting revision.

### 11. AI Use Statement

AI tools were used to assist with implementation planning, code development, debugging, and explanations of Unity components and game-feel techniques.

The generated code and implementation suggestions were reviewed, integrated, tested, and adjusted in Unity.

### 12. Asset and Tool Credits

- Unity 6.3 – Game development environment.
- Freesound – Audio assets listed in the audio credits section.
- GitHub – Source code version control.
- OBS Studio – Video recording (if used).
- AI assistance – Planning, coding support, and debugging.

The original starter project's MIT license and source credit are retained.

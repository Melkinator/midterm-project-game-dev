# Midterm Project — 3D Platformer

A 3D obstacle-course platformer built in Unity (URP) where players navigate moving platforms, swinging pendulums, and hazards to reach the finish line as fast as possible.

---

## Objective

Navigate through the 3D platformer course from the **Start** trigger to the **Finish** line in the shortest time possible while avoiding hazards and obstacles.

---

## Rules

- The timer begins when the player touches the **Start** trigger.
- Avoid hazards (spinning obstacles, rolling hazards, swinging pendulums, and falling off platforms) — colliding with hazards or falling triggers Game Over.
- Reach the **Finish** trigger to stop the timer and complete the level.
- Your final completion time is displayed on the Win screen, where you can restart or quit.

---

## Controls

| Action | Input |
| :--- | :--- |
| Move | `W` `A` `S` `D` or `Arrow Keys` |
| Camera Look | `Mouse` (cursor locked during gameplay) |
| Jump | `Space` |
| Dash | `Left Shift` |
| Pause / Resume | `Escape` |

---

## Unity Version

- **Unity:** `6000.3.8f1` (Unity 6)
- **Render Pipeline:** Universal Render Pipeline (URP)

---

## Setup & Play Instructions

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd midterm-project-game-dev
   ```
2. **Open in Unity:**
   - Open **Unity Hub** and add the project folder.
   - Launch the project using **Unity 6000.3.8f1**.
3. **Open the main scene:**
   - In the Project window, open `Assets/POLY STYLE - Platformer Starter Pack/Platformer Starter Pack_URP/Scene/DemoScene.unity`.
4. **Play:**
   - Press the **Play** button in the Unity Editor.

---

## 4. Playable Build (Standalone — Windows x86_64)

A standalone **Windows x86_64** build is submitted for this project. It runs on its own and **does not require the Unity Editor** to be installed or opened.

**Download:** [midterm-project-win64.zip](https://github.com/OWNER/REPO/releases/latest/download/midterm-project-win64.zip)

> Replace `OWNER/REPO` with the GitHub repository path once the build is attached to a Release.

**How to play:**

1. Download `midterm-project-win64.zip` and extract it (keep all files and folders together).
2. Run `midterm-project.exe`.
3. Play using the controls listed in the **Controls** section above.

**Requirements:**

- Windows 10 / 11 (64-bit)
- GPU with DirectX 11 support or newer
- No Unity installation needed

**First launch:** Windows SmartScreen may warn about an unsigned build — click **More info → Run anyway**.

**Rebuild it yourself:**

1. Open the project in **Unity 6000.3.8f1**.
2. Ensure the scenes in **File > Build Settings** are, in order:
   - `Platformer Starter Pack_URP/Scene/DemoScene` (index 0)
   - `Platformer Starter Pack_URP/Scene/GameOver` (index 1)
3. Select **Windows, Mac, Linux > Windows x86_64** and click **Build**.

> `Build/` and `Builds/` are git-ignored, so the compiled build is distributed through GitHub Releases rather than committed to the repository.

---

## Project Structure

- `Assets/Scripts/PlayerController.cs` — Camera-relative movement, jumping, and dashing.
- `Assets/Scripts/CameraFollow.cs` — Third-person camera follow and mouse orbit (`ThirdPersonCamera`).
- `Assets/Scripts/GameController.cs` — Start/Finish trigger timer, win screen, and restart/quit logic.
- `Assets/Scripts/PauseMenu.cs` — Pause menu (`Escape`), resume, restart, and exit.
- `Assets/POLY STYLE - Platformer Starter Pack/Platformer Starter Pack_URP/Scene/DemoScene.unity` — Main playable level.

---

## Team Members & Contributions

> *Update with your team members and their specific contributions:*

- **[Team Member 1]** — Level design, map layout, hazards & obstacles
- **[Team Member 2]** — Player controller, camera follow, game controller, pause menu

---

## Asset & Tutorial References

- **Assets:**
  - [POLY STYLE - Platformer Starter Pack (URP)](Assets/POLY%20STYLE%20-%20Platformer%20Starter%20Pack/Readme.txt)
  - Unity **TextMesh Pro**
- **Tutorials / References:**
  - *Add any Unity or YouTube tutorials referenced during development here.*

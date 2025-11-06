# Hướng dẫn Setup High Score System

## Các file đã tạo:
1. **HighScoreData.cs** - Class lưu trữ dữ liệu high score
2. **HighScoreManager.cs** - Singleton quản lý lưu/load high scores
3. **LeaderboardUI.cs** - UI component để hiển thị leaderboard

## Cách setup trong Unity:

### 1. Tạo HighScoreManager GameObject:
- Tạo một GameObject mới trong scene MainMenu (hoặc scene đầu tiên)
- Đặt tên: "HighScoreManager"
- Add component: `HighScoreManager`
- GameObject này sẽ tự động DontDestroyOnLoad để giữ qua các scene

### 2. Setup MPCanvas (Multiplayer Scene):
- Mở scene MultiPlayer
- Chọn GameObject có component `MPCanvas`
- Trong Inspector, thêm các TextMeshPro components:
  - **highScoreText** (Array): 2 TextMeshPro để hiển thị high score cho Player 1 và Player 2
  - **newRecordText** (Array): 2 TextMeshPro để hiển thị "NEW RECORD!" (có thể để trống nếu không muốn)
  - **personalBestText**: 1 TextMeshPro để hiển thị Personal Best tổng thể

### 3. Setup Leaderboard UI (Main Menu):
- Trong scene MainMenu, tạo một Panel mới cho Leaderboard
- Tạo GameObject mới và add component `LeaderboardUI`
- Trong Inspector, setup:
  - **leaderboardPanel**: Kéo Panel vào đây
  - **rankTexts** (Array): 10 TextMeshPro để hiển thị rank (#1, #2, ...)
  - **scoreTexts** (Array): 10 TextMeshPro để hiển thị điểmm
  - **dateTexts** (Array): 10 TextMeshPro để hiển thị ngày (có thể để trống)
  - **personalBestDisplay**: TextMeshPro để hiển thị Personal Best ở menu chính
  - **noScoresText**: GameObject hiển thị "No scores yet" khi chưa có điểm

### 4. Setup MenuController:
- Chọn GameObject có component `MenuController`
- Trong Inspector, kéo component `LeaderboardUI` vào field **leaderboardUI**
- Tạo button "Leaderboard" trong Main Menu và gán method `LeaderboardClicked()` vào OnClick

## Tính năng:
- ✅ Tự động lưu điểm cao nhất (Personal Best)
- ✅ Lưu top 10 high scores với ngày giờ
- ✅ Hiển thị "NEW RECORD!" khi đạt điểm cao mới
- ✅ Hiển thị leaderboard trong menu
- ✅ Dữ liệu được lưu bằng PlayerPrefs (persistent)

## API sử dụng:
```csharp
// Kiểm tra và lưu điểm
bool isNewRecord = HighScoreManager.Instance.CheckAndSaveScore(score, playerNumber);

// Lấy personal best
int best = HighScoreManager.Instance.GetPersonalBest();

// Lấy top scores
List<HighScoreData> topScores = HighScoreManager.Instance.GetTopScores(10);

// Xóa tất cả (reset)
HighScoreManager.Instance.ClearAllHighScores();
```

## Lưu ý:
- HighScoreManager tự động tạo nếu chưa có trong scene
- Dữ liệu được lưu tự động khi game over
- Có thể để trống các field tùy chọn trong Inspector nếu không muốn hiển thị


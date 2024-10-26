# Mục Lục
1. [Tạo Project - Bố cục làm việc - Cấu trúc Project](#tạo-project---bố-cục-làm-việc---cấu-trúc-project)
   - 1.1 [Tạo Project](#tạo-project)
   - 1.2 [Bố cục làm việc](#bố-cục-làm-việc)
   - 1.3 [Cấu trúc Project](#cấu-trúc-project)
2. [Thành phần Scene](#thành-phần-scene)
3. [Camera](#camera)
4. [Game Object trong Unity](#game-object-trong-unity)
   - 4.1 [Game Object là gì?](#1-game-object-là-gì)
   - 4.2 [Các đặc điểm của Game Object](#2-các-đặc-điểm-của-game-object)
   - 4.3 [Tạo Game Object](#3-tạo-game-object)
   - 4.4 [Các GameObject trong Unity tuân theo một vòng đời cố định](#4-các-gameobject-trong-unity-tuân-theo-một-vòng-đời-cố-định)
5. [Prefab](#prefab)
6. [Thành phần SpriteRenderer](#thành-phần-spriterenderer)
7. [Sử dụng Tag](#sử-dụng-tag)
8. [Sorting Layer và Order In Layer](#sorting-layer-và-order-in-layer)
9. [Vector](#vector)
---
# Tạo Project - Bố cục làm việc - Cấu trúc Project
#### **Tạo Project** 
**Unity Hub** > `New project` > chọn `Template` > Đặt tên > `Create project`

- Unity cung cấp nhiều mẫu project khác nhau như 2D, 3D, VR/AR, hay các templates khác tùy thuộc vào nhu cầu. 
#### Bố cục làm việc
- **Scene View**: Nơi bạn chỉnh sửa cảnh. 

- **Game View**: Hiển thị cách game sẽ được hiển thị khi chạy.

- **Inspector**: Hiển thị thông tin chi tiết của các thành phần (Components) của GameObject.

- **Hierarchy**: Hiển thị cấu trúc cây của các GameObject trong Scene.

- **Project**: Hiển thị các tài nguyên (assets) trong project của bạn.

#### Cấu trúc Project
Thư mục Assets là nơi chứa các tài nguyên của project, bao gồm textures, scripts, materials, prefabs và models.

---
# Thành phần Scene
- Scene là một không gian chứa các GameObject trong Unity. 
- Mỗi Scene có thể chứa các yếu tố như nhân vật, môi trường, ánh sáng, camera, và các đối tượng tương tác khác. 
- Có thể lưu, tải và chuyển đổi giữa nhiều Scene khác nhau trong game.
---
# Camera
Camera là đối tượng dùng để hiển thị thế giới 2D hoặc 3D trên màn hình. 
- Trong Unity, camera mặc định là camera 3D. 

Có thể tùy chỉnh góc nhìn, vị trí và nhiều thuộc tính khác của camera để tạo ra góc nhìn phù hợp cho game.

---
# Game Object trong Unity

## 1. Game Object là gì?
- **Game Object** (Đối tượng trong game) là thành phần cơ bản trong Unity, đóng vai trò như một container để chứa và quản lý các thành phần (Components) khác nhau.
- Tất cả mọi thứ trong Unity, từ nhân vật, đối tượng môi trường, tới ánh sáng và âm thanh, đều được tạo nên từ các Game Object.

## 2. Các đặc điểm của Game Object
- **Không có hình dạng hay hành vi cụ thể**. Để Game Object hoạt động, chúng cần được thêm các **Component**
- **Component** là các thành phần giúp GameObject có các thuộc tính và hành vi. Mỗi GameObject có thể chứa nhiều Component như:
    - **Transform**: Quản lý vị trí, xoay, và tỷ lệ của GameObject.
    - **Rigidbody**: Thêm thuộc tính vật lý cho GameObject, cho phép nó tương tác với thế giới vật lý.
    - **Collider**: Giúp GameObject có thể va chạm hoặc phát hiện va chạm với các đối tượng khác.
## 3. Tạo Game Object
Trong Unity, có một số cách để tạo ra một Game Object:
- **Tạo từ menu**: Vào **`GameObject > Create Empty`** hoặc chọn các loại đối tượng có sẵn như Cube, Sphere, Plane, etc.
- **Tạo bằng script**: Sử dụng phương thức `GameObject.Instantiate` để tạo ra đối tượng mới trong code.

Ví dụ Code
```csharp
GameObject newObject = new GameObject("TênĐốiTượng");
```
## 4. Các GameObject trong Unity tuân theo một vòng đời cố định
- **`Awake()`** Gọi khi GameObject được khởi tạo.
- **`Start()`** Gọi khi GameObject được kích hoạt.
- **`Update()`** Gọi mỗi khung hình để cập nhật logic.
- **`FixedUpdate()`** Gọi định kỳ với tốc độ khung hình cố định, dùng cho vật lý.
- **`LateUpdate()`** Gọi sau Update, thường dùng để đồng bộ camera hoặc các đối tượng khác sau khi logic chính được cập nhật.
- **`OnDestroy()`** Gọi khi GameObject bị hủy.
---
# Prefab
Prefab là một mẫu của GameObject đã được lưu lại để sử dụng lại nhiều lần trong game. 

Prefab cho phép bạn tạo một đối tượng và lưu nó, sau đó bạn có thể sử dụng lại hoặc instantiate nó ở bất kỳ đâu trong Scene mà không cần tạo lại từ đầu.

---
# Thành phần SpriteRenderer

**SpriteRenderer** là một component quan trọng trong Unity cho các game 2D, dùng để hiển thị hình ảnh (*sprites*) trên màn hình. Thành phần này chịu trách nhiệm render sprite của GameObject lên màn hình, giúp bạn đưa các hình ảnh như nhân vật, đối tượng, hoặc nền (*background*) vào game.

- **Cách thêm SpriteRenderer**: Chọn GameObject trong Unity Editor, vào *Inspector*, nhấp **Add Component** và chọn **Sprite Renderer**.
- **Thiết lập Sprite**: Bạn có thể gán một sprite cụ thể cho thành phần này để hiển thị nó trên GameObject. 
---
# Sử dụng Tag

**Tag** là một cách gán nhãn cho GameObject để phân loại và dễ quản lý. Tag có thể được sử dụng để tìm kiếm hoặc truy cập đối tượng cụ thể.

Ví dụ, gán Tag `"Player"` cho nhân vật chính hoặc `"Enemy"` cho kẻ thù.

- **Tạo Tag mới**: Trong *Inspector*, bạn nhấp vào thẻ *Tag* ở phía trên cùng của GameObject, chọn **Add Tag...**, sau đó thêm Tag mới.
- **Cách sử dụng Tag trong code**:
  ```csharp
  GameObject player = GameObject.FindGameObjectWithTag("Player");
  if (player != null)
  {
      // Thực hiện hành động với player
  }
  ```

# Sorting Layer và Order In Layer

- **Sorting Layer**: Là lớp hiển thị các đối tượng trong game 2D. Các đối tượng trên các layer khác nhau sẽ được sắp xếp theo thứ tự mong muốn để tránh chồng lên nhau không đúng. 

    Ví dụ, layer `"Background"` sẽ luôn hiển thị sau layer `"Player"`.

- **Order In Layer**: Được sử dụng để quyết định thứ tự hiển thị của các đối tượng trong cùng một *Sorting Layer*. Giá trị cao hơn sẽ được render trước các giá trị thấp hơn, đảm bảo các đối tượng ở thứ tự mong muốn khi chúng cùng lớp.
---
# Vector
Vector trong Unity được sử dụng để biểu diễn các đại lượng có hướng, như vị trí, vận tốc hay lực. 

Hai loại vector phổ biến nhất là:
- Vector2: Dùng trong không gian 2D (X, Y).
    ```csharp
    Vector2 position2D = new Vector2(3.0f, 4.0f);
    ```
- Vector3: Dùng trong không gian 3D (X, Y, Z).
    ```csharp
    Vector3 position3D = new Vector3(3.0f, 4.0f, 5.0f);
    ```


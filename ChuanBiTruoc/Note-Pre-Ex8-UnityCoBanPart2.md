# Mục lục
1. **[Rigidbody](#1-rigidbody)**
2. **[Collision và Trigger](#2-collision-và-trigger)**
3. **[Bắt va chạm (Collision Detection)](#3-bắt-va-chạm-collision-detection)**
4. **[Bắt va chạm với Trigger](#4-bắt-va-chạm-với-trigger)**
5. **[IEnumerator](#5-ienumerator)**
6. **[Invoke](#6-invoke)**
7. **[TimeScale](#7-timescale)**
8. **[Giới thiệu về Animation](#8-giới-thiệu-về-animation)**
---
### 1. **Rigidbody**
Rigidbody là thành phần vật lý quan trọng trong Unity, dùng để mô phỏng các tính chất vật lý như trọng lực, va chạm, và tương tác lực với môi trường.

- **Mass**: Khối lượng của đối tượng, quyết định khả năng phản ứng khi bị tác động bởi lực. Vật thể có khối lượng lớn sẽ khó bị đẩy hơn so với vật có khối lượng nhỏ.
  ```csharp
  // Thay đổi khối lượng của một Rigidbody
  Rigidbody rb = GetComponent<Rigidbody>();
  rb.mass = 5f; // Đặt khối lượng là 5
  ```

- **Drag**: Lực cản khi đối tượng di chuyển, lực cản lớn sẽ làm đối tượng di chuyển chậm hơn.
  ```csharp
  rb.drag = 1f; // Lực cản là 1
  ```

- **Angular Drag**: Lực cản khi đối tượng quay. Điều chỉnh thông số này nếu muốn đối tượng quay chậm lại theo thời gian.
  ```csharp
  rb.angularDrag = 0.5f; // Lực cản xoay là 0.5
  ```

- **Use Gravity**: Đặt `true` để cho phép trọng lực tác động lên đối tượng.
  ```csharp
  rb.useGravity = true; // Đối tượng sẽ chịu tác động của trọng lực
  ```

- **Is Kinematic**: Khi bật, đối tượng không bị ảnh hưởng bởi các lực vật lý và chỉ có thể di chuyển bằng mã lập trình.
  ```csharp
  rb.isKinematic = true; // Đối tượng sẽ không bị ảnh hưởng bởi lực vật lý
  ```
- **Collision Detection Mode**: Xác định cách phát hiện va chạm.
  - **Discrete**: Thông thường và hiệu quả nhất, nhưng có thể bỏ sót va chạm nếu vật thể di chuyển quá nhanh.
  - **Continuous**: Phát hiện tốt hơn cho vật thể di chuyển nhanh.
  - **Continuous Dynamic**: Dành cho đối tượng có Rigidbody di chuyển nhanh, giúp tránh bỏ sót va chạm với các vật thể tĩnh.

  ```csharp
  rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
  ```

### 2. **Collision và Trigger**
- **Collision**: Được sử dụng để mô phỏng va chạm vật lý giữa các đối tượng có Collider và Rigidbody. Unity tự động xử lý các va chạm và bạn có thể bắt sự kiện để thêm các hành động bổ sung.
  
  Ví dụ về bắt va chạm:
  ```csharp
  void OnCollisionEnter(Collision collision) {
      Debug.Log("Va chạm với: " + collision.gameObject.name);
  }
  ```

- **Trigger**: Sử dụng khi không muốn xử lý va chạm vật lý nhưng vẫn cần phát hiện khi có đối tượng khác đi vào vùng của Collider.
  
  Ví dụ về bắt sự kiện Trigger:
  ```csharp
  void OnTriggerEnter(Collider other) {
      Debug.Log("Đối tượng đi vào Trigger: " + other.gameObject.name);
  }
  ```

- **Collision Layers**: Unity cung cấp khả năng cài đặt các lớp (layer) để chỉ định đối tượng nào có thể va chạm với nhau. Có thể sử dụng **Layer Collision Matrix** để thiết lập chi tiết.

  `Edit` > `Project Settings...` > `Physics`/`Physics 2D`
  
  ```csharp
  // Kiểm tra nếu đối tượng va chạm là một đối tượng thuộc lớp "Enemy"
  if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
      Debug.Log("Va chạm với kẻ địch!");
  }
  ```

### 3. **Bắt va chạm (Collision Detection)**
Unity cung cấp các phương thức để bắt sự kiện va chạm giữa các đối tượng có Collider và Rigidbody.

- **OnCollisionEnter()**: Được gọi khi hai đối tượng bắt đầu va chạm.
- **OnCollisionStay()**: Được gọi khi hai đối tượng vẫn đang va chạm liên tục.
- **OnCollisionExit()**: Được gọi khi hai đối tượng ngừng va chạm.

Ví dụ:
```csharp
void OnCollisionEnter(Collision collision) {
    Debug.Log("Va chạm với đối tượng: " + collision.gameObject.name);
}
```

### 4. **Bắt va chạm với Trigger**
Trigger được sử dụng khi bạn chỉ cần phát hiện sự kiện, mà không xử lý va chạm vật lý thực sự. Bạn có thể sử dụng `IsTrigger` trên Collider để chuyển chế độ này.

- **OnTriggerEnter()**: Được gọi khi một đối tượng đi vào vùng Trigger.
- **OnTriggerStay()**: Được gọi khi một đối tượng ở trong vùng Trigger.
- **OnTriggerExit()**: Được gọi khi một đối tượng rời khỏi vùng Trigger.

Ví dụ:
```csharp
void OnTriggerEnter(Collider other) {
    Debug.Log("Đối tượng đi vào Trigger: " + other.gameObject.name);
}
```

### 5. **IEnumerator**
IEnumerator trong Unity là một giao diện cho phép tạo ra các **Coroutines** – các hàm có thể tạm dừng trong một khoảng thời gian rồi tiếp tục thực hiện mà không ảnh hưởng đến các hoạt động khác trong game.

Có thể sử dụng `WaitForFixedUpdate`, `WaitForEndOfFrame`, hoặc các điều kiện khác để tạm dừng.
Ví dụ về Coroutine để delay một hành động:
```csharp
IEnumerator DelayExample() {
    Debug.Log("Bắt đầu");
    yield return new WaitForSeconds(2); // Dừng 2 giây
    Debug.Log("Kết thúc sau 2 giây");
}
```
Cách sử dụng Coroutine:
```csharp
StartCoroutine(DelayExample());
```

### 6. **Invoke**
**`Invoke()`** là phương thức cho phép bạn gọi một hàm sau một khoảng thời gian trễ. Đây là cách đơn giản để tạo độ trễ mà không cần phải dùng Coroutine.

Ví dụ:
```csharp
void Start() {
    Invoke("DelayedFunction", 3f); // Gọi hàm DelayedFunction sau 3 giây
}

void DelayedFunction() {
    Debug.Log("Hàm được gọi sau 3 giây");
}
```
**`InvokeRepeating()`**: Bạn có thể sử dụng phương thức này để gọi một hàm theo chu kỳ. Đây là một cách đơn giản để thực hiện các hành động lặp đi lặp lại với thời gian cố định.

  ```csharp
  void Start() {
      InvokeRepeating("RepeatFunction", 2f, 1f); // Gọi RepeatFunction sau 2 giây, lặp lại mỗi giây
  }

  void RepeatFunction() {
      Debug.Log("Hàm được gọi lặp lại");
  }
  ```

### 7. **TimeScale**
`Time.timeScale` cho phép điều chỉnh tốc độ thời gian trong game. Nó ảnh hưởng đến tất cả các vật thể trong game ngoại trừ các thành phần không dựa vào thời gian vật lý (như UI).

- Để tạm dừng game:
  ```csharp
  Time.timeScale = 0; // Dừng thời gian
  ```

- Để giảm tốc độ game:
  ```csharp
  Time.timeScale = 0.5f; // Tốc độ game chỉ còn một nửa
  ```

- Để khôi phục tốc độ bình thường:
  ```csharp
  Time.timeScale = 1; // Khôi phục tốc độ game
  ```

Ví dụ tạm dừng và tiếp tục game:
```csharp
void PauseGame() {
    Time.timeScale = 0; // Tạm dừng game
}

void ResumeGame() {
    Time.timeScale = 1; // Tiếp tục game
}
```
- **Ảnh hưởng đến các hàm sử dụng thời gian thực**: Khi `Time.timeScale` = 0, các hàm như `WaitForSeconds()` trong Coroutine sẽ bị dừng. Sử dụng `WaitForSecondsRealtime()` để không bị ảnh hưởng bởi `timeScale`.

  ```csharp
  IEnumerator PauseCoroutine() {
      yield return new WaitForSecondsRealtime(2); // Sẽ không bị ảnh hưởng bởi Time.timeScale
      Debug.Log("Đã tiếp tục sau 2 giây thực");
  }
  ```

### 8. **Giới thiệu về Animation**
[2D Animation in Unity By Brackeys](https://youtu.be/hkaysu1Z-N8?si=WYtBkb7QZgehCp4H)

Unity sử dụng hệ thống **Animator** để điều khiển các animation. Animator Controller chứa các trạng thái animation và các điều kiện để chuyển đổi giữa chúng.

- **Animator Controller**: Điều khiển các trạng thái animation của một đối tượng.
- **Animation Clip**: Đoạn animation riêng lẻ, có thể tạo ra bằng các công cụ như Blender, Maya, hoặc tạo trực tiếp trong Unity.
- **Parameter**: Các biến như `bool`, `float`, hoặc `trigger` để điều khiển việc chuyển đổi giữa các trạng thái.

Ví dụ về sử dụng `Trigger` để chuyển từ trạng thái đứng yên sang chạy:
```csharp
Animator animator = GetComponent<Animator>();
animator.SetTrigger("Run");
```
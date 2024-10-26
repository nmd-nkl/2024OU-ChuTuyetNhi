## Mục lục
1. [Sử dụng Instantiate để tạo đối tượng](#su-dung-instantiate-de-tao-doi-tuong)
2. [Destroy](#destroy)
3. [SetActive](#setactive)
4. [AddComponent](#addcomponent)
5. [GetComponent](#getcomponent)
---
#### [Unity Documentation - GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html)
---
## Sử dụng Instantiate để tạo đối tượng

Phương thức `Instantiate` cho phép sao chép một đối tượng hiện có hoặc tạo mới đối tượng dựa trên một mẫu.

### Khai báo Instantiate

Các cách sử dụng phổ biến của hàm `Instantiate`:

```csharp
public static Object Instantiate(Object original);
```

```csharp
public static Object Instantiate(Object original, Transform parent);
```

```csharp
public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace);
```

```csharp
public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
```

```csharp
public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
```

### Tham số của hàm Instantiate

- **original**: Đối tượng gốc mà bạn muốn sao chép.
- **position**: Vị trí khởi đầu của đối tượng mới.
- **rotation**: Hướng khởi đầu của đối tượng mới.
- **parent**: Đối tượng cha sẽ được gán cho đối tượng mới.
- **instantiateInWorldSpace**: Nếu `true`, đặt vị trí đối tượng mới trong không gian thế giới; nếu `false`, đặt vị trí theo cha.

### Ví dụ về Instantiate

```csharp
// Tạo một bản sao đơn giản của đối tượng
Instantiate(originalObject);   
// Tạo một bản sao và gán đối tượng cha
Instantiate(originalObject, parentTransform);
// Tạo một bản sao với đối tượng cha và thiết lập trong không gian thế giới
Instantiate(originalObject, parentTransform, true);    
// Tạo một bản sao ở vị trí và hướng cụ thể
Instantiate(originalObject, new Vector3(0, 0, 0), Quaternion.identity);   
// Tạo một bản sao ở vị trí và hướng cụ thể, đồng thời gán đối tượng cha
Instantiate(originalObject, new Vector3(0, 0, 0), Quaternion.identity,parentTransform);
```
## Destroy

Hàm `Destroy` dùng để xóa một đối tượng sau khi hoàn thành công việc hoặc khi không còn cần thiết.

```csharp
// Xóa ngay lập tức
Destroy(gameObject);
// Xóa sau một khoảng thời gian (ví dụ: 2 giây)
Destroy(gameObject, 2.0f);
```
## SetActive
Hàm `SetActive` cho phép bật/tắt một Game Object.
```csharp
// Bật đối tượng
gameObject.SetActive(true);
// Tắt đối tượng
gameObject.SetActive(false);
```
## AddComponent
Hàm `AddComponent` dùng để thêm thành phần mới vào Game Object.
```csharp
// Thêm một Rigidbody vào Game Object
gameObject.AddComponent<Rigidbody>();
// Thêm một Collider vào Game Object
gameObject.AddComponent<BoxCollider>();
```
## GetComponent

Hàm `GetComponent` cho phép truy xuất một thành phần (component) cụ thể trên GameObject hiện tại.
### Ví dụ

```csharp
// Lấy thành phần Rigidbody từ GameObject hiện tại
Rigidbody rb = gameObject.GetComponent<Rigidbody>();

// Lấy thành phần BoxCollider từ GameObject hiện tại
BoxCollider boxCollider = (BoxCollider)gameObject.GetComponent(typeof(BoxCollider));
```

Nếu thành phần không tồn tại, hàm sẽ trả về `null`.

## GetComponentInParent

Hàm `GetComponentInParent` dùng để lấy một thành phần từ GameObject cha gần nhất.
### Ví dụ

```csharp
// Lấy thành phần Animator từ GameObject cha gần nhất
Animator animator = gameObject.GetComponentInParent<Animator>();
```

## GetComponentInChildren

Hàm `GetComponentInChildren` dùng để tìm kiếm và lấy một thành phần từ các GameObject con.

### Cú pháp

```csharp
public T GetComponentInChildren<T>(bool includeInactive = false);
public Component GetComponentInChildren(Type type, bool includeInactive = false);
```

- `includeInactive`: Nếu `true`, hàm sẽ tìm cả trong những GameObject con đang bị vô hiệu hóa.

### Ví dụ

```csharp
// Lấy thành phần Light từ các GameObject con
Light childLight = gameObject.GetComponentInChildren<Light>();

// Lấy thành phần ParticleSystem từ các GameObject con, bao gồm cả đối tượng đang bị tắt
ParticleSystem particleSystem = gameObject.GetComponentInChildren<ParticleSystem>(true);
```

## Truy xuất Siblings

Các đối tượng "siblings" là những đối tượng con cùng thuộc một cha (parent). Để truy xuất một sibling, có thể sử dụng cách thức truy xuất cha của đối tượng hiện tại rồi duyệt qua các con của cha đó.

### Ví dụ

```csharp
// Lấy cha của GameObject hiện tại
Transform parentTransform = gameObject.transform.parent;

if (parentTransform != null)
{
    // Duyệt qua tất cả các con của cha
    foreach (Transform sibling in parentTransform)
    {
        // Bỏ qua đối tượng hiện tại
        if (sibling != gameObject.transform)
        {
            Debug.Log("Sibling: " + sibling.name);
        }
    }
}
```
# A* Path Finding

## Node
```csharp
bool isObstacle;//Là vật cản?

float gCost; //Chi phí từ điểm bắt đầu đến hiện tại
float hCost; //Chi phí nút hiện tại đến đích
float FCost => gCost + hCost;//Tổng chi phí

Node prevNode;//Node trước tối ưu
List<Node> neighbors = new List<Node>();//Lưu các ô lân cận
```

## A* 
```csharp
    [Header("List in Gameplay")]
    public List<Node> resultPath = new List<Node>();
    public List<Node> frontierNodes = new List<Node>(); //Danh sách các ô mở rộng đến được
    public List<Node> exploredNodes = new List<Node>(); //Danh sách các ô đã duyệt

    [Header("Nodes in Gameplay")]
    public Node player;
    public Node target;
    public Node currentNode;

    [Header("Time")]
    float timeFind;
```
```csharp
    public void StartFinding(Node startNode, Node endNode) {
        player = startNode;
        frontierNodes.Add(startNode);
        target = endNode;
        if(FindPath()) {
            BuildPath(endNode);
        } else {
            Debug.Log("Cant find Path!");
        }
    }
```
```csharp
    bool FindPath() {
        timeFind = Time.time;
        if (frontierNodes.Count <= 0) { //Danh sách mở rộng trống
            Debug.LogError("Zero Block to Move");
            return false;
        }
        if (frontierNodes.Contains(target)) { //Đích là ô liền kề
            Debug.LogWarning("One Block");
            return true;
        }
        if (target == player) { //Ô hiện tại là đích
            Debug.LogWarning("Zero Block");
            return true;
        }
        while (currentNode != target) {
            currentNode = null;
            currentNode = BestNodeCostFrontier();//Tìm bestCost

            if (currentNode == null) {
                Debug.LogError("Not found target");
                return false;
            }

            if (target == currentNode) {
                Debug.Log("Done");
                return true;
            }

            if (AddedExplored(currentNode)) { //Đưa note hiện tại vào danh sách đã duyệt
                AddNeighborsFrontier(currentNode); //Đưa các node lân cận của currNode vào danh sách mở rộng
            } else {
                Debug.LogError("Bug Frontier to Explored Node");
            }
        }
        timeFind = Time.time - timeFind;
        return true;
    }
```
```csharp
    //Tìm Node có Fcost thấp nhất, nếu bằng nhau thì ưu tiên hCost
    Node BestNodeCostFrontier() {
        if (frontierNodes.Count == 0) return null;

        Node bestNode = frontierNodes[0];

        foreach (var node in frontierNodes) {
            if (node.FCost < bestNode.FCost || (node.FCost == bestNode.FCost && node.hCost < bestNode.hCost)) {
                bestNode = node;
            }
        }

        return bestNode;
    }
```
```csharp
void AddNeighborsFrontier(Node node) {
    // Lặp qua tất cả các nút lân cận của nút hiện tại
    foreach (var neighbor in node.neighbors) {
        // Nếu nút lân cận là chướng ngại vật (không thể đi qua), bỏ qua nó
        if (neighbor.isObstacle == true) continue;
        
        // Kiểm tra nếu nút lân cận đã có trong danh sách frontier
        if (frontierNodes.Contains(neighbor)) {
            // Nếu đã có, kiểm tra và thay đổi nút "trước đó" của nút lân cận nếu cần thiết
            CheckChangeNodePrevious(node, neighbor);
        }
        else {
            // Nếu nút lân cận chưa có trong frontier
            if (AddFrontier(neighbor)) {
                // Thêm nút lân cận vào frontier và thiết lập nút trước đó của nó là nút hiện tại
                neighbor.prevNode = node;
            }
            // Tính toán gCost, là chi phí từ nút khởi đầu đến nút lân cận qua nút hiện tại
            neighbor.gCost = node.gCost + Vector2.Distance(node.transform.position, neighbor.transform.position);
        }
    }
}

```
```csharp
    void CheckChangeNodePrevious(Node current, Node neighbor) {
        // chi phí di chuyển từ điểm bắt đầu đến node neighbor thông qua current
        float FCostNeighborWithCurrent = current.gCost + Vector2.Distance(current.transform.position, neighbor.transform.position);
        
        bool checkFCost = FCostNeighborWithCurrent < neighbor.FCost;
        bool checkHCost = (FCostNeighborWithCurrent == neighbor.FCost) && (current.hCost < neighbor.prevNode.hCost);

        if (checkFCost || checkHCost) {
            neighbor.prevNode = current;
            neighbor.gCost = FCostNeighborWithCurrent;
        }
    }
```
```csharp
    bool AddFrontier(Node node) {
        //Không là vật cản
        //Không có sẵn trong ds mở rộng || đã duyệt
        if (node.isObstacle == true) return false;
        if (!frontierNodes.Contains(node) && !exploredNodes.Contains(node)) {
            frontierNodes.Add(node);
            return true;
        }
        return false;
    }
```
```csharp
    bool AddedExplored(Node node) {
        if (!exploredNodes.Contains(node)) {
            exploredNodes.Add(node);//đã duyệt
            frontierNodes.Remove(node);//xoá khỏi mở rộng
            return true;
        }
        return false;
    }
```
```csharp
    void BuildPath(Node endNode) {
        resultPath.Clear();
        Node current = endNode;

        while (current != null) {
            if (!current.isObstacle) {
                resultPath.Add(current);
            }
            current = current.prevNode;
        }

        resultPath.Reverse();
    }
```
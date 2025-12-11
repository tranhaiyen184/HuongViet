# Hướng dẫn sử dụng hệ thống quản lý khách hàng và đơn hàng

## Tổng quan

Hệ thống đã được mở rộng để hỗ trợ quản lý khách hàng, đơn hàng và điểm tích lũy theo database schema được cung cấp. Các tính năng chính bao gồm:

- **Quản lý khách hàng**: Thêm, sửa, xóa, tìm kiếm khách hàng
- **Quản lý đơn hàng**: Tạo đơn hàng, cập nhật trạng thái, tìm kiếm
- **Hệ thống điểm tích lũy**: Tự động tích điểm và sử dụng điểm

## Cấu trúc dự án

### Models (HuongViet.Models)
- `Customer.cs` - Model khách hàng
- `Order.cs` - Model đơn hàng với các enum trạng thái
- `OrderDetail.cs` - Model chi tiết đơn hàng
- `AccumulatedPoints.cs` - Model điểm tích lũy

### Data Access Layer (HuongViet.DAL)
- `CustomerDAL.cs` - Truy cập dữ liệu khách hàng
- `OrderDAL.cs` - Truy cập dữ liệu đơn hàng
- `AccumulatedPointsDAL.cs` - Truy cập dữ liệu điểm tích lũy

### Business Logic Layer (HuongViet.BLL)
- `CustomerBLL.cs` - Logic nghiệp vụ khách hàng
- `OrderBLL.cs` - Logic nghiệp vụ đơn hàng
- `AccumulatedPointsBLL.cs` - Logic nghiệp vụ điểm tích lũy

## Cách sử dụng

### 1. Quản lý khách hàng

```csharp
var customerBLL = new CustomerBLL();

// Tạo khách hàng mới
var customer = new Customer
{
    CustomerID = customerBLL.GenerateNewCustomerID(),
    CustomerName = "Nguyễn Văn A",
    CustomerPhoneNum = "0901234567",
    CustomerEmail = "nguyenvana@email.com",
    CustomerDOB = new DateTime(1990, 1, 1)
};

customerBLL.Insert(customer);

// Tìm khách hàng theo số điện thoại
var foundCustomer = customerBLL.GetByPhoneNumber("0901234567");

// Tạo khách hàng nhanh (chỉ cần tên và số điện thoại)
var quickCustomer = customerBLL.CreateQuickCustomer("Trần Thị B", "0987654321");
```

### 2. Tạo đơn hàng

```csharp
var orderBLL = new OrderBLL();

// Tạo chi tiết đơn hàng
var orderDetails = new List<OrderDetail>
{
    new OrderDetail
    {
        ItemID = "ITEM001",
        Quantity = 2,
        UnitPrice = 50000,
        Discount = 0,
        Note = "Ít cay"
    },
    new OrderDetail
    {
        ItemID = "ITEM002",
        Quantity = 1,
        UnitPrice = 25000,
        Discount = 10, // Giảm 10%
        Note = "Không đá"
    }
};

// Tạo đơn hàng nhanh
var order = orderBLL.CreateQuickOrder(
    customerName: "Nguyễn Văn A",
    customerPhone: "0901234567",
    staffId: "USER001",
    formOfService: FormOfService.DineIn,
    orderDetails: orderDetails,
    tableId: "TABLE001"
);

// Cập nhật trạng thái đơn hàng
orderBLL.UpdateStatus(order.OrderID, OrderStatus.Confirmed);
orderBLL.UpdateStatus(order.OrderID, OrderStatus.Preparing);
orderBLL.UpdateStatus(order.OrderID, OrderStatus.Completed);
```

### 3. Quản lý điểm tích lũy

```csharp
var pointsBLL = new AccumulatedPointsBLL();

// Kiểm tra điểm hiện tại
int currentPoints = pointsBLL.GetCurrentPoints("CUST000001");

// Kiểm tra có thể sử dụng điểm không
bool canUse = pointsBLL.CanUsePoints("CUST000001", 50);

// Sử dụng điểm (50 điểm = 50,000 VND giảm giá)
if (canUse)
{
    pointsBLL.UsePoints("CUST000001", 50);
}

// Tính điểm từ số tiền đơn hàng
int earnedPoints = pointsBLL.CalculatePointsFromAmount(100000); // 10 điểm

// Tính giá trị tiền từ điểm
decimal discountAmount = pointsBLL.CalculateAmountFromPoints(50); // 50,000 VND
```

### 4. Tìm kiếm và phân trang

```csharp
// Tìm kiếm khách hàng
var customerCriteria = new SearchCriteria
{
    SearchTerm = "Nguyễn",
    PageNumber = 1,
    PageSize = 10,
    SortBy = "CustomerName",
    SortDirection = "ASC"
};

var customerResult = customerBLL.SearchCustomers(customerCriteria);

// Tìm kiếm đơn hàng
var orderCriteria = new SearchCriteria
{
    SearchTerm = "0901234567", // Tìm theo số điện thoại
    PageNumber = 1,
    PageSize = 20
};

var orderResult = orderBLL.SearchOrders(
    criteria: orderCriteria,
    status: OrderStatus.Completed,
    fromDate: DateTime.Today.AddDays(-30),
    toDate: DateTime.Today
);
```

## Quy tắc nghiệp vụ

### Điểm tích lũy
- **Tích điểm**: 1 điểm cho mỗi 10,000 VND (khi đơn hàng hoàn thành)
- **Sử dụng điểm**: 1 điểm = 1,000 VND giảm giá
- Điểm chỉ được cộng khi đơn hàng có trạng thái `Completed`

### Trạng thái đơn hàng
1. `Pending` - Chờ xác nhận
2. `Confirmed` - Đã xác nhận
3. `Preparing` - Đang chuẩn bị
4. `Ready` - Sẵn sàng
5. `Served` - Đã phục vụ
6. `Completed` - Hoàn thành
7. `Cancelled` - Đã hủy

### Validation
- **Khách hàng**: Tên không quá 50 ký tự, số điện thoại không quá 15 ký tự, email hợp lệ
- **Đơn hàng**: Phải có ít nhất 1 chi tiết, tổng tiền >= 0
- **Điểm tích lũy**: Điểm hiện tại không được âm, không được lớn hơn tổng điểm

## Database Schema

Hệ thống sử dụng các bảng sau:
- `customers` - Thông tin khách hàng
- `orders` - Thông tin đơn hàng
- `order_details` - Chi tiết đơn hàng
- `accumulated_points` - Điểm tích lũy

## Lưu ý khi sử dụng

1. **Soft Delete**: Tất cả các thao tác xóa đều là soft delete (cập nhật `DeletedAt`)
2. **Transaction**: Tạo đơn hàng sử dụng transaction để đảm bảo tính nhất quán
3. **Auto ID**: Các ID được tự động sinh theo format:
   - Customer: `CUST000001`
   - Order: `ORD000001`
   - AccumulatedPoints: `AP000001`
4. **Error Handling**: Tất cả các method đều có xử lý exception và thông báo lỗi tiếng Việt

## Ví dụ hoàn chỉnh

Xem file `OrderManagementExample.cs` để có ví dụ chi tiết về cách sử dụng các tính năng.

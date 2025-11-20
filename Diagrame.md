// Use DBML to define your database structure
// Docs: https://dbml.dbdiagram.io/docs

// Define Enums
Enum ItemType {
  "Thức ăn"
  "Nước uống"
  "Dịch vụ"
}

Enum TableStatus {
  "Available"
  "Occupied"
  "Reserved"
  "Maintenance"
}

Enum RoomType {
  "Phòng thường"
  "Phòng VIP"
}

Enum RoomStatus {
  "Available"
  "Occupied"
  "Reserved"
  "Cleaning"
  "Maintenance"
}

Enum OrderStatus {
  "Pending"
  "Confirmed"
  "Preparing"
  "Ready"
  "Served"
  "Completed"
  "Cancelled"
}

Enum PaymentMethod {
  "Cash"
  "Credit Card"
  "Debit Card"
  "Bank Transfer"
  "QR Code"
  "E-Wallet"
}

Enum FormOfService {
  "Dine In"
  "Takeaway"
  "Delivery"
  "Room Service"
}

Enum ReservationStatus {
  "Pending"
  "Confirmed"
  "Cancelled"
  "Completed"
  "No Show"
  "Checked In"
}

Enum TableOccupancyStatus {
  "Available"
  "Occupied"
  "Reserved"
  "Cleaning"
  "Maintenance"
}

Table Permission {
  PermissionID varchar [primary key]
  PermissionCode varchar(50) [not null]
  PermissionName varchar(50) [not null]
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table Role {
  RoleID varchar [primary key]
  RoleCode varchar(50) [not null]
  RoleName varchar(50) [not null]
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table User {
  UserID varchar [primary key]
  LastName varchar(20) [not null]
  FirstName varchar(20) [not null]
  PhoneNumber varchar(15)
  UserName varchar(20) [not null, unique]
  Password varchar(255) [not null, note: 'Hashed password']
  PositionID varchar
  RoleID varchar [not null]
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table Position {
  PositionID varchar [primary key]
  PositionName varchar(30) [not null]
  DepartmentID varchar
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table Department {
  DepartmentID varchar [primary key]
  DepartmentName varchar(30) [not null]
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table Area {
  AreaID varchar [primary key]
  AreaName varchar(30)
}

Table Tables {
  TableID varchar [primary key]
  TableName varchar(20) [not null]
  TableStatus TableOccupancyStatus [default: 'Available']
  Capacity integer [not null]
  AreaID varchar [not null]
  CurrentOrderID varchar [note: 'Order hiện tại đang sử dung bàn (nullable)']
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table Room {
  RoomID varchar [primary key]
  RoomName varchar(30) [not null]
  RoomStatus RoomStatus [default: 'Available']
  RoomType RoomType [not null]
  PricePerHour decimal(10,2) [not null]
  Capacity integer [not null]
  AreaID varchar [not null]
  CurrentOrderID varchar [note: 'Order hiện tại đang sử dụng phòng (nullable)']
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table Categories {
  CateID varchar [primary key]
  CateName varchar(50)
  CateDescription varchar
}

Table Items {
  ItemID varchar [primary key]
  ItemName varchar(50) [not null]
  ItemImage varchar(200)
  ItemType ItemType [not null]
  ItemPrice decimal(10,2) [not null]
  ItemDescription varchar(100)
  CateID varchar [not null]
  UnitID varchar [not null]
  IsActive boolean [default: true]
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table Units {
  UnitID varchar [primary key]
  UnitName varchar(50)
}

Table Order {
  OrderID varchar [primary key]
  OrderDate datetime [default: `now()`]
  OrderTime datetime [default: `now()`]
  OrderStatus OrderStatus [default: 'Pending']
  OrderNote varchar(200)
  FormOfService FormOfService [not null]
  PaymentMethod PaymentMethod
  TotalAmount decimal(12,2) [default: 0]
  CustomerID varchar [note: 'Khách hàng thành viên (nullable)']
  CustomerName varchar(50) [note: 'Tên khách hàng - bắt buộc cho cả walk-in và reservation']
  CustomerPhone varchar(15) [note: 'SĐT khách hàng - bắt buộc']
  TableID varchar [note: 'Bàn thực tế sử dụng']
  RoomID varchar [note: 'Phòng thực tế sử dụng']
  ReservationID varchar [note: 'NULL = walk-in customer, có giá trị = từ đặt bàn trước']
  StaffID varchar [not null, note: 'Nhân viên tạo hóa đơn']
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
  
  Note: '2 cách tạo: 1) Walk-in: tạo Order trực tiếp 2) Reservation: từ đặt bàn có sẵn'
}

Table Customer {
  CustomerID varchar [primary key]
  CustomerName varchar(50) [not null]
  CustomerPhoneNum varchar(15) [not null, unique]
  CustomerEmail varchar(100)
  CustomerDOB datetime
  CusAssignDate datetime [default: `now()`]
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
}

Table Reservation {
  ReservationID varchar [primary key]
  CustomerName varchar(50) [not null, note: 'Tên khách đặt bàn']
  ContactPhone varchar(15) [not null, note: 'Số điện thoại liên hệ']
  CustomerID varchar [note: 'Liên kết với Customer nếu có tài khoản, nullable']
  TableID varchar
  RoomID varchar
  ReservationDate date [not null]
  ReservationTime time [not null]
  NumberOfGuests integer [not null]
  Duration integer [note: 'Duration in hours']
  ReservationStatus ReservationStatus [default: 'Pending']
  SpecialRequests text
  DepositAmount decimal(10,2) [default: 0]
  created_at timestamp [default: `now()`]
  updated_at timestamp [default: `now()`]
  
  Note: 'Đặt bàn đơn giản: chỉ cần tên và số điện thoại. CustomerID nullable cho khách vãng lai'
}

Table "Order Details" {
  OrderID varchar [pk]
  ItemID varchar [pk]
  Quantity integer [not null]
  UnitPrice decimal(10,2) [not null]
  TotalAmount decimal(10,2) [not null]
  Discount decimal(5,2) [default: 0]
  Note text
}

Table "Banks Transaction" {
  TransactionID varchar [primary key]
  TransferName varchar(100)
  Amount decimal
  OrderID varchar
  BankID varchar
}

Table "Accumulated Points" {
  AccumulatedPointID varchar [primary key]
  CustomerID varchar [not null]
  AccumPoint integer [default: 0]
  TotalAccumPoint integer [default: 0]
  UpdateDate datetime [default: `now()`]
  created_at timestamp [default: `now()`]
}

// Relationships
Ref: User.PositionID > Position.PositionID // many-to-one (User holds Position)
Ref: Position.DepartmentID > Department.DepartmentID // many-to-one
Ref: Tables.AreaID > Area.AreaID // many-to-one (Tables belong to Area)
Ref: Room.AreaID > Area.AreaID // many-to-one (Rooms belong to Area)
Ref: Items.CateID > Categories.CateID // many-to-one (Items belong to Categories)
Ref: Items.UnitID > Units.UnitID // many-to-one (Items use Units)
Ref: "Order Details".OrderID > Order.OrderID // many-to-one
Ref: "Order Details".ItemID > Items.ItemID // many-to-one
Ref: Order.CustomerID > Customer.CustomerID // many-to-one (Orders belong to Customer)
Ref: "Banks Transaction".OrderID > Order.OrderID // many-to-one
Ref: "Accumulated Points".CustomerID > Customer.CustomerID // many-to-one
Ref: Order.TableID > Tables.TableID // many-to-one (Order can use Table)
Ref: Order.RoomID > Room.RoomID // many-to-one (Order can use Room)

// Reservation relationships
Ref: Reservation.CustomerID > Customer.CustomerID // many-to-one (Optional - for registered customers)
Ref: Reservation.TableID > Tables.TableID // many-to-one (Reservation for Table)
Ref: Reservation.RoomID > Room.RoomID // many-to-one (Reservation for Room)

// Order relationships with Staff and Reservation
Ref: Order.StaffID > User.UserID // many-to-one (Staff creates Order)
Ref: Order.ReservationID > Reservation.ReservationID // many-to-one (Order from Reservation)

// Current occupancy tracking
Ref: Tables.CurrentOrderID > Order.OrderID // one-to-one (Current order using table)
Ref: Room.CurrentOrderID > Order.OrderID // one-to-one (Current order using room)

// Create junction table for Permission-Role many-to-many relationship
Table "Role Permission" {
  RoleID varchar [pk]
  PermissionID varchar [pk]
  created_at timestamp [default: `now()`]
}

// Additional relationships for permissions and roles
Ref: "Role Permission".RoleID > Role.RoleID
Ref: "Role Permission".PermissionID > Permission.PermissionID
Ref: User.RoleID > Role.RoleID // many-to-one (User has Role)
```
DROP DATABASE huongviet;

CREATE DATABASE huongviet;
USE huongviet;

-- ============================
-- 1. DEPARTMENTS
-- ============================
CREATE TABLE departments (
    DepartmentID VARCHAR(255) PRIMARY KEY,
    DepartmentName VARCHAR(30) NOT NULL,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- 2. POSITIONS
-- ============================
CREATE TABLE positions (
    PositionID VARCHAR(255) PRIMARY KEY,
    PositionName VARCHAR(30) NOT NULL,
    DepartmentID VARCHAR(255),
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_position_department FOREIGN KEY (DepartmentID)
        REFERENCES departments(DepartmentID)
);

-- ============================
-- 3. ROLES
-- ============================
CREATE TABLE roles (
    RoleID VARCHAR(255) PRIMARY KEY,
    RoleCode VARCHAR(50) NOT NULL UNIQUE,
    RoleName VARCHAR(50) NOT NULL,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- 4. PERMISSIONS
-- ============================
CREATE TABLE permissions (
    PermissionID VARCHAR(255) PRIMARY KEY,
    PermissionCode VARCHAR(50) NOT NULL UNIQUE,
    PermissionName VARCHAR(50) NOT NULL,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- 5. ROLE - PERMISSION (N-N)
-- ============================
CREATE TABLE role_permissions (
    RoleID VARCHAR(255) NOT NULL,
    PermissionID VARCHAR(255) NOT NULL,
    PRIMARY KEY (RoleID, PermissionID),

    CONSTRAINT fk_rolepermission_role FOREIGN KEY (RoleID)
        REFERENCES roles(RoleID),

    CONSTRAINT fk_rolepermission_permission FOREIGN KEY (PermissionID)
        REFERENCES permissions(PermissionID)
);

-- ============================
-- 6. USERS
-- ============================
CREATE TABLE users (
    UserID VARCHAR(255) PRIMARY KEY,
    LastName VARCHAR(20) NOT NULL,
    FirstName VARCHAR(20) NOT NULL,
    PhoneNumber VARCHAR(15),
    UserName VARCHAR(20) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL COMMENT 'Hashed password',
    PositionID VARCHAR(255),
    RoleID VARCHAR(255) NOT NULL,
    Status ENUM('active', 'inactive') DEFAULT 'active',
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    CONSTRAINT fk_user_position FOREIGN KEY (PositionID)
        REFERENCES positions(PositionID),
        
    CONSTRAINT fk_user_role FOREIGN KEY (RoleID)
        REFERENCES roles(RoleID)
);

-- ============================
-- 7. AREA (KHU VỰC)
-- ============================
CREATE TABLE areas (
    AreaID VARCHAR(255) PRIMARY KEY,
    AreaName VARCHAR(30) NOT NULL,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- 8. TABLES (BÀN)
-- ============================
CREATE TABLE tables (
    TableID VARCHAR(255) PRIMARY KEY,
    TableName VARCHAR(20) NOT NULL,
    TableStatus ENUM('Available','Occupied','Cleaning','Unavailable') DEFAULT 'Available',
    Capacity INT NOT NULL,
    AreaID VARCHAR(255) NOT NULL,
    CurrentOrderID VARCHAR(255) NULL COMMENT 'Order hiện tại đang sử dụng bàn',
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_table_area FOREIGN KEY (AreaID)
        REFERENCES areas(AreaID)
);

-- ============================
-- 9. ROOMS (PHÒNG)
-- ============================
CREATE TABLE rooms (
    RoomID VARCHAR(255) PRIMARY KEY,
    RoomName VARCHAR(30) NOT NULL,
    RoomStatus ENUM('Available','InUse','Maintenance','Closed') DEFAULT 'Available',
    RoomType ENUM('Normal','VIP') NOT NULL,
    PricePerHour DECIMAL(10,2) NOT NULL,
    Capacity INT NOT NULL,
    AreaID VARCHAR(255) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_room_area FOREIGN KEY (AreaID)
        REFERENCES areas(AreaID)
); 

CREATE TABLE categories (
    CateID VARCHAR(255) PRIMARY KEY,
    CateName VARCHAR(50) NOT NULL,
    CateDescription VARCHAR(255),
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- 3. TABLE Units
-- ============================
CREATE TABLE units (
    UnitID VARCHAR(255) PRIMARY KEY,
    UnitName VARCHAR(50) NOT NULL,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- 4. TABLE Items
-- ============================
CREATE TABLE items (
    ItemID VARCHAR(255) PRIMARY KEY,
    ItemName VARCHAR(50) NOT NULL,
    ItemImage TEXT,
    ItemType ENUM('Thức ăn','Nước uống','Dịch vụ') NOT NULL,
    ItemPrice DECIMAL(10,2) NOT NULL,
    ItemDescription VARCHAR(100),
    CateID VARCHAR(255) NOT NULL,
    UnitID VARCHAR(255) NOT NULL,
    IsActive BOOLEAN DEFAULT TRUE,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_items_category FOREIGN KEY (CateID)
        REFERENCES categories(CateID),

    CONSTRAINT fk_items_unit FOREIGN KEY (UnitID)
        REFERENCES units(UnitID)
);

-- ============================
-- 5. TABLE ItemsPrice
-- ============================
CREATE TABLE item_prices (
    PriceUpdateDate DATETIME NOT NULL,
    ItemID VARCHAR(255) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    PRIMARY KEY (PriceUpdateDate, ItemID),

    CONSTRAINT fk_price_item FOREIGN KEY (ItemID)
        REFERENCES items(ItemID)
);

CREATE TABLE customers (
    CustomerID VARCHAR(255) PRIMARY KEY,
    CustomerName VARCHAR(50) NOT NULL,
    CustomerPhoneNum VARCHAR(15) NOT NULL UNIQUE,
    CustomerEmail VARCHAR(100),
    CustomerDOB DATETIME,
    CusAssignDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
CREATE TABLE reservations (
    ReservationID VARCHAR(255) PRIMARY KEY,
    CustomerName VARCHAR(50) NOT NULL,
    ContactPhone VARCHAR(15) NOT NULL,
    CustomerID VARCHAR(255) NULL,
    TableID VARCHAR(255),
    RoomID VARCHAR(255),
    ReservationDate DATE NOT NULL,
    ReservationTime TIME NOT NULL,
    NumberOfGuests INT NOT NULL,
    Duration INT,
    ReservationStatus ENUM('Pending','Confirmed','Cancelled') DEFAULT 'Pending',
    SpecialRequests TEXT,
    DepositAmount DECIMAL(10,2) DEFAULT 0,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_reservation_customer FOREIGN KEY (CustomerID)
        REFERENCES customers(CustomerID)
);
CREATE TABLE orders (
    OrderID VARCHAR(255) PRIMARY KEY,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    OrderTime DATETIME DEFAULT CURRENT_TIMESTAMP,
    OrderStatus ENUM('Pending','Confirmed','Preparing','Ready','Served','Completed','Cancelled') DEFAULT 'Pending',
    OrderNote VARCHAR(200),
    FormOfService ENUM('Dine In','Takeaway') NOT NULL,
    PaymentMethod ENUM('Cash','Bank Transfer'),
    TotalAmount DECIMAL(12,2) DEFAULT 0,

    CustomerID VARCHAR(255),
    CustomerName VARCHAR(50) NOT NULL,
    CustomerPhone VARCHAR(15) NOT NULL,
    TableID VARCHAR(255),
    RoomID VARCHAR(255),
    ReservationID VARCHAR(255),
    StaffID VARCHAR(255) NOT NULL,

    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_order_customer FOREIGN KEY (CustomerID)
        REFERENCES customers(CustomerID),

    CONSTRAINT fk_order_reservation FOREIGN KEY (ReservationID)
        REFERENCES reservations(ReservationID)
);

CREATE TABLE order_details (
    OrderID VARCHAR(255) NOT NULL,
    ItemID VARCHAR(255) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    Discount DECIMAL(5,2) DEFAULT 0,
    Note TEXT,

    PRIMARY KEY (OrderID, ItemID),

    CONSTRAINT fk_orderdetails_order FOREIGN KEY (OrderID)
        REFERENCES orders(OrderID),

    CONSTRAINT fk_orderdetails_item FOREIGN KEY (ItemID)
        REFERENCES items(ItemID)
);
CREATE TABLE accumulated_points (
    AccumulatedPointID VARCHAR(255) PRIMARY KEY,
    CustomerID VARCHAR(255) NOT NULL,
    AccumPoint INT DEFAULT 0,
    TotalAccumPoint INT DEFAULT 0,
    UpdateDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    DeletedAt TIMESTAMP NULL DEFAULT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_accumpoint_customer FOREIGN KEY (CustomerID)
        REFERENCES customers(CustomerID)
);

CREATE TABLE vouchers (
    id CHAR(36) NOT NULL PRIMARY KEY,
    code VARCHAR(64) NOT NULL UNIQUE,
    percentage DECIMAL(5,2) NOT NULL CHECK (percentage > 0 AND percentage <= 100),
    description TEXT,
    start_at DATETIME DEFAULT NULL,
    end_at DATETIME DEFAULT NULL,
    usage_limit INT DEFAULT NULL,
    usage_count INT NOT NULL DEFAULT 0,
    active TINYINT(1) NOT NULL DEFAULT 1,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
```


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

Tạo role: ADMIN
Tạo User: admin|Admin@123

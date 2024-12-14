# Ecommerce System - Web API

## Overview

The **Ecommerce System** is a Web API designed for managing products, categories, users, and carts in an online store. The API allows users to view products, filter them by name or category, and manage their shopping cart. Admin users have full control over product and category management, including creating, modifying, and deleting them. Regular users can view and interact with the products, apply pagination, and manage their cart.

This project is built using **ASP.NET Core Web API** and follows a **Role-Based Access Control (RBAC)** model with two roles: **Admin** and **User**.

## Features

### 1. User Management
   - **Admin**:
     - Can create, read, update, and delete (`CRUD`) products and categories.
     - Manages product attributes such as name, quantity, price, and category.
     - Creates new categories for products.
   - **User**:
     - Can view products.
     - Can filter products by name and category.
     - Can add products to their shopping cart.
     - Can delete individual products from their cart.
     - Can clear all products from their cart.

### 2. Product Management
   - Admin can create, update, or delete products in the system.
   - Products have the following attributes:
     - **Name**
     - **Quantity**
     - **Price**
     - **Category**

### 3. Category Management
   - Admin can create, update, or delete product categories.
   - Categories allow products to be grouped and filtered by category.

### 4. Product Filtering and Pagination (For Users)
   - Users can filter products by:
     - **Product Name** (partial match)
     - **Category ID**
   - Users can view products with pagination to manage large datasets.

### 5. Shopping Cart Management (For Users)
   - Users can manage their cart with the following actions:
     - **Add a Product** to the cart.
     - **Remove a Product** from the cart.
     - **Clear All Products** in the cart.
     - **Get All Products** from the cart.

### 6. Role-Based Access Control (RBAC)
   - **Admin** has the ability to manage products, categories, and users.
   - **User** has the ability to view products, filter them, and interact with their shopping cart.

## Technologies Used
- **ASP.NET Core Web API**: For building the API.
- **Entity Framework Core**: For database access.
- **SQL Server**: Database backend.
- **JWT Authentication**: For securing API endpoints.
- **Swagger**: For API documentation and testing.

  ![image](https://github.com/user-attachments/assets/22425388-a360-4f41-bc92-4d03a780dbc4)

-- =============================================
-- Order Management Database Schema
-- =============================================

-- Create Database
CREATE DATABASE IF NOT EXISTS order_management;
USE order_management;

-- Orders Table
CREATE TABLE orders (
    id INT AUTO_INCREMENT PRIMARY KEY,
    customer_name VARCHAR(100) NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL,
    is_complete BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Insert sample data
INSERT INTO orders (customer_name, total_amount, is_complete) VALUES
('Alice', 150.00, TRUE),
('Bob', 200.00, FALSE),
('Carol', 320.50, TRUE);

-- =============================================
-- Useful Queries
-- =============================================

-- Get all complete orders
SELECT * FROM orders WHERE is_complete = TRUE;

-- Get total revenue from complete orders
SELECT SUM(total_amount) AS total_revenue 
FROM orders 
WHERE is_complete = TRUE;

-- Get orders sorted by amount
SELECT * FROM orders ORDER BY total_amount DESC;

-- Update order status
UPDATE orders SET is_complete = TRUE WHERE id = 2;

-- Count orders per status
SELECT 
    is_complete AS status,
    COUNT(*) AS count,
    SUM(total_amount) AS total
FROM orders
GROUP BY is_complete;

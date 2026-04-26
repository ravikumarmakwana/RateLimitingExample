# 🚀 ASP.NET Core Rate Limiting

## 🔥 Overview

This project demonstrates how to implement **production-ready rate limiting** in ASP.NET Core.

It covers all major rate-limiting strategies with real-world configuration, clean structure, and extensibility.

---

## ⚡ Features

- ✅ Fixed Window Rate Limiting  
- ✅ Sliding Window Rate Limiting  
- ✅ Token Bucket Rate Limiting  
- ✅ Concurrency Limiting  
- ✅ Partitioned Rate Limiting (per IP / user)  
- ✅ Config-driven setup via `appsettings.json`  
- ✅ Custom 429 response handling

  <img width="1908" height="515" alt="ShareX_3oBFXPnJii" src="https://github.com/user-attachments/assets/af83da2b-a5c2-4a86-8c9b-7410c80bba3c" />

---

## ⚙️ Rate Limiting Strategies

### 1. Fixed Window
- Allows a fixed number of requests per time window  
- Simple and predictable  

### 2. Sliding Window
- Distributes requests more smoothly  
- Prevents burst spikes  

### 3. Token Bucket
- Allows short bursts of traffic  
- Tokens refill over time  

### 4. Concurrency Limiter
- Limits number of concurrent requests  
- Ideal for heavy operations  

### 5. Partitioned Limiter
- Applies limits per user/IP  
- Ensures fairness  

---

## 🔗 API Endpoints

| Endpoint | Description |
|--------|------------|
| `/api/ratelimiter/fixed` | Fixed window limiter |
| `/api/ratelimiter/sliding` | Sliding window limiter |
| `/api/ratelimiter/token` | Token bucket limiter |
| `/api/ratelimiter/concurrency` | Concurrency limiter |
| `/api/ratelimiter/partitioned` | Per-user/IP limiter |

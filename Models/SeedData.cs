using Microsoft.EntityFrameworkCore;

namespace Developer_Task_Manager.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Projects.Any())
        {
            return;
        }

        // Add Projects
        List<Project> projects = new List<Project>
        {
            new Project { Name = "E-Commerce Platform", Description = "Full-stack e-commerce web application with payment integration" },
            new Project { Name = "Mobile Banking App", Description = "Cross-platform mobile banking solution for iOS and Android" },
            new Project { Name = "Healthcare Portal", Description = "Patient management system with appointment scheduling" },
            new Project { Name = "Learning Management System", Description = "Educational platform for online courses and assessments" },
            new Project { Name = "Inventory Management", Description = "Real-time inventory tracking and warehouse management" },
            new Project { Name = "Social Media Dashboard", Description = "Analytics dashboard for social media marketing" },
            new Project { Name = "IoT Smart Home", Description = "Home automation system with IoT device integration" },
            new Project { Name = "CRM System", Description = "Customer relationship management for sales teams" },
            new Project { Name = "DevOps Pipeline", Description = "CI/CD automation and infrastructure as code" },
            new Project { Name = "AI Chatbot", Description = "Intelligent customer support chatbot with NLP" }
        };
        context.AddRange(projects);
        context.SaveChanges();

        // Add Categories
        List<Category> categories = new List<Category>
        {
            new Category { Name = "Bug Fix", Description = "Fixing existing bugs and issues in the codebase" },
            new Category { Name = "Feature", Description = "New feature development and enhancements" },
            new Category { Name = "Documentation", Description = "Technical documentation and user guides" },
            new Category { Name = "Testing", Description = "Unit tests, integration tests, and QA" },
            new Category { Name = "UI/UX", Description = "User interface and experience improvements" },
            new Category { Name = "Performance", Description = "Performance optimization and profiling" },
            new Category { Name = "Security", Description = "Security audits, patches, and compliance" },
            new Category { Name = "Refactoring", Description = "Code cleanup and architectural improvements" },
            new Category { Name = "DevOps", Description = "Deployment, monitoring, and infrastructure" },
            new Category { Name = "Research", Description = "Technical research and proof of concepts" }
        };
        context.AddRange(categories);
        context.SaveChanges();

        // Add Tasks
        List<TaskItem> tasks = new List<TaskItem>
        {
            // E-Commerce Platform tasks
            new TaskItem { Title = "Fix checkout payment bug", Description = "Users receiving error on final payment step", Priority = "High", Status = "In Progress", Assignee = "John", DueDate = DateTime.Parse("2024-12-20"), ProjectID = 1, CategoryID = 1 },
            new TaskItem { Title = "Implement product search", Description = "Add advanced search with filters and sorting", Priority = "High", Status = "To Do", Assignee = "Sarah", DueDate = DateTime.Parse("2024-12-25"), ProjectID = 1, CategoryID = 2 },
            new TaskItem { Title = "Add product reviews feature", Description = "Allow customers to leave ratings and reviews", Priority = "Medium", Status = "To Do", Assignee = "Mike", DueDate = DateTime.Parse("2025-01-05"), ProjectID = 1, CategoryID = 2 },

            // Mobile Banking App tasks
            new TaskItem { Title = "Fix biometric login crash", Description = "App crashes on Face ID authentication on iOS 17", Priority = "High", Status = "In Progress", Assignee = "Emily", DueDate = DateTime.Parse("2024-12-15"), ProjectID = 2, CategoryID = 1 },
            new TaskItem { Title = "Implement push notifications", Description = "Real-time transaction alerts and account updates", Priority = "Medium", Status = "To Do", Assignee = "David", DueDate = DateTime.Parse("2024-12-30"), ProjectID = 2, CategoryID = 2 },
            new TaskItem { Title = "Security audit for API", Description = "Penetration testing and vulnerability assessment", Priority = "High", Status = "To Do", Assignee = "Chris", DueDate = DateTime.Parse("2024-12-18"), ProjectID = 2, CategoryID = 7 },

            // Healthcare Portal tasks
            new TaskItem { Title = "Design appointment UI", Description = "Create wireframes for appointment booking flow", Priority = "Medium", Status = "Done", Assignee = "Lisa", DueDate = DateTime.Parse("2024-12-10"), ProjectID = 3, CategoryID = 5 },
            new TaskItem { Title = "Write API documentation", Description = "Document all REST endpoints for third-party integration", Priority = "Low", Status = "In Progress", Assignee = "Tom", DueDate = DateTime.Parse("2024-12-28"), ProjectID = 3, CategoryID = 3 },
            new TaskItem { Title = "Add patient dashboard", Description = "Dashboard showing upcoming appointments and medical history", Priority = "High", Status = "To Do", Assignee = "Anna", DueDate = DateTime.Parse("2025-01-10"), ProjectID = 3, CategoryID = 2 },

            // Learning Management System tasks
            new TaskItem { Title = "Optimize video streaming", Description = "Reduce buffering time for course videos", Priority = "High", Status = "In Progress", Assignee = "Kevin", DueDate = DateTime.Parse("2024-12-22"), ProjectID = 4, CategoryID = 6 },
            new TaskItem { Title = "Create unit tests for grading", Description = "Add comprehensive tests for grading engine", Priority = "Medium", Status = "To Do", Assignee = "Rachel", DueDate = DateTime.Parse("2024-12-31"), ProjectID = 4, CategoryID = 4 },
            new TaskItem { Title = "Refactor course module", Description = "Clean up legacy code in course management", Priority = "Low", Status = "To Do", Assignee = "Brian", DueDate = DateTime.Parse("2025-01-15"), ProjectID = 4, CategoryID = 8 },

            // Inventory Management tasks
            new TaskItem { Title = "Fix stock count discrepancy", Description = "Database showing incorrect inventory levels", Priority = "High", Status = "In Progress", Assignee = "Nancy", DueDate = DateTime.Parse("2024-12-16"), ProjectID = 5, CategoryID = 1 },
            new TaskItem { Title = "Add barcode scanner support", Description = "Integrate mobile barcode scanning for stock updates", Priority = "Medium", Status = "To Do", Assignee = "Steve", DueDate = DateTime.Parse("2025-01-08"), ProjectID = 5, CategoryID = 2 },

            // Social Media Dashboard tasks
            new TaskItem { Title = "Research analytics APIs", Description = "Evaluate Twitter and Instagram API capabilities", Priority = "Medium", Status = "Done", Assignee = "Jessica", DueDate = DateTime.Parse("2024-12-08"), ProjectID = 6, CategoryID = 10 },
            new TaskItem { Title = "Design dashboard layout", Description = "Create responsive dashboard with charts and graphs", Priority = "High", Status = "In Progress", Assignee = "Mark", DueDate = DateTime.Parse("2024-12-24"), ProjectID = 6, CategoryID = 5 },

            // IoT Smart Home tasks
            new TaskItem { Title = "Fix device pairing issue", Description = "Bluetooth devices not pairing reliably", Priority = "High", Status = "To Do", Assignee = "Paul", DueDate = DateTime.Parse("2024-12-19"), ProjectID = 7, CategoryID = 1 },
            new TaskItem { Title = "Add voice control feature", Description = "Integrate with Alexa and Google Assistant", Priority = "Medium", Status = "To Do", Assignee = "Laura", DueDate = DateTime.Parse("2025-01-20"), ProjectID = 7, CategoryID = 2 },

            // CRM System tasks
            new TaskItem { Title = "Performance testing", Description = "Load test CRM with 10K concurrent users", Priority = "High", Status = "To Do", Assignee = "James", DueDate = DateTime.Parse("2024-12-23"), ProjectID = 8, CategoryID = 4 },
            new TaskItem { Title = "Improve lead scoring algorithm", Description = "ML-based lead scoring optimization", Priority = "Medium", Status = "In Progress", Assignee = "Amy", DueDate = DateTime.Parse("2025-01-12"), ProjectID = 8, CategoryID = 6 },

            // DevOps Pipeline tasks
            new TaskItem { Title = "Setup Kubernetes cluster", Description = "Deploy production K8s cluster on AWS", Priority = "High", Status = "In Progress", Assignee = "Robert", DueDate = DateTime.Parse("2024-12-17"), ProjectID = 9, CategoryID = 9 },
            new TaskItem { Title = "Create deployment docs", Description = "Document CI/CD pipeline and deployment process", Priority = "Medium", Status = "To Do", Assignee = "Karen", DueDate = DateTime.Parse("2024-12-29"), ProjectID = 9, CategoryID = 3 },

            // AI Chatbot tasks
            new TaskItem { Title = "Train NLP model", Description = "Fine-tune GPT model for customer support domain", Priority = "High", Status = "In Progress", Assignee = "Alex", DueDate = DateTime.Parse("2024-12-21"), ProjectID = 10, CategoryID = 10 },
            new TaskItem { Title = "Add sentiment analysis", Description = "Detect customer sentiment for escalation routing", Priority = "Medium", Status = "To Do", Assignee = "Michelle", DueDate = DateTime.Parse("2025-01-03"), ProjectID = 10, CategoryID = 2 },
            new TaskItem { Title = "Security review for data handling", Description = "Ensure PII data is handled according to GDPR", Priority = "High", Status = "To Do", Assignee = "Chris", DueDate = DateTime.Parse("2024-12-26"), ProjectID = 10, CategoryID = 7 }
        };
        context.AddRange(tasks);
        context.SaveChanges();
    }
}

workspace {

    !adrs decisions

    model {
        user = person "User" "Uses the system."

        enterprise "Enterprise" {
            backendSystem = softwareSystem "Backend" {
                api = container "Web API" "Backend API" ".NET 7 Web API"
                database = container "Database" "Entity persistence database." "Mongo DB" "Database"
            }
            frontend = softwareSystem "Frontend!"
        }

        user -> frontend "Interacts with"
        frontend -> api "Makes requests to"
        api -> database "Reads from and writes to"
    }

    views {

        systemLandscape "SystemLandscape" {
            include *
            autoLayout
        }

        container backendSystem "Containers" {
            include *
            autoLayout
        }

        styles {
            element "External" {
                background #999999
                color #ffffff
            }
            element "Platform" {
                background #33ccff
                color #ffffff
            }
            element "Database" {
                shape Cylinder
            }
        } 

        theme default

    }
}
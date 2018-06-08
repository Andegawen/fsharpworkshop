module Types

open System

type PersonalDetails = {
    FirstName:string
    LastName:string
    DOB: DateTime
}

[<Measure>] type EUR
[<Measure>] type USD

type Notifications =
    | NoNotifications
    | ReceiveNotifications of receiveDeals : bool * receiveAlerts:bool

type Customer = {
    Id: int
    IsVip:bool
    Credit: decimal<USD>
    PersonalDetails: PersonalDetails option
    Notifications: Notifications
}
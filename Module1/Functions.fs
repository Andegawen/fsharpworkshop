module Functions

open Types
open System
open FSharp.Data

let tryPromoteToVip purchases = 
    let customer, amount = purchases
    if amount > 100M then {customer with IsVip = true }
    else customer


type Json = JsonProvider<"Data.json">

let getPurchases customer =
    let purchases = Json.Load "Data.json"
                    |> Seq.filter (fun c-> c.CustomerId = customer.Id)
                    |> Seq.collect (fun c-> c.PurchasesByMonth)
                    |> Seq.average
    (customer, purchases)

let increaseCredit condition customer =
    if condition customer then {customer  with Credit = customer.Credit + 100M<USD>}
    else {customer with Credit = customer.Credit + 50M<USD>}

let increaseCreditUsingVip = increaseCredit (fun c-> c.IsVip)

let upgradeCustomer = getPurchases >> tryPromoteToVip >> increaseCreditUsingVip

let isAdult customer =
    match customer.PersonalDetails with
    | None -> false
    | Some c -> c.DOB.AddYears 18 <= DateTime.Now.Date

let getAlert (customer:Customer) =
    match customer.Notifications with
    | ReceiveNotifications(receiveAlerts = true) ->
        sprintf "Alert for customer %i" customer.Id
    | _ -> ""
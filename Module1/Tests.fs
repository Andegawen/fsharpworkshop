module Tests

open Xunit
open Swensen.Unquote
open Types
open Functions
open System

//[<Fact>]
//let ``1-1 Create customer``() =
//    let customer = { Id = 1; IsVip = false; Credit = 0M }
//    test <@ customer.GetType () = typeof<Customer> @>

//[<Fact>]
//let ``1-2 Promote to vip``() =
//    let customer = { Id = 1; IsVip = false; Credit = 0M }
//    let promotedCustomer = tryPromoteToVip (customer, 100.1M)
//    test <@ promotedCustomer.IsVip = true @>

//[<Fact>]
//let ``1-3 Do not promote to vip``() =
//    let customer = { Id = 1; IsVip = false; Credit = 0M }
//    let promotedCustomer = tryPromoteToVip (customer, 99.9M)
//    test <@ promotedCustomer.IsVip = false @>

//[<Fact>]
//let ``1-4 Get purchases for odd customers``() =
//    let customer = { Id = 1; IsVip = false; Credit = 0M }
//    let _, purchases = getPurchases customer
//    test <@ purchases = 80M @>

//[<Fact>]
//let ``1-5 Get purchases for even customers``() =
//    let customer = { Id = 2; IsVip = false; Credit = 0M }
//    let _, purchases = getPurchases customer
//    test <@ purchases = 120M @>

//[<Fact>]
//let ``2-1 Increase min credit using id``() =
//    let customer = { Id = 1; IsVip = false; Credit = 0M }
//    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
//    test <@ upgradedCustomer.Credit = 50M @>

//[<Fact>]
//let ``2-2 Increase max credit using id``() =
//    let customer = { Id = 2; IsVip = false; Credit = 0M }
//    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
//    test <@ upgradedCustomer.Credit = 100M @>

//[<Fact>]
//let ``2-3 Increase credit keeping existing one``() =
//    let customer = { Id = 2; IsVip = false; Credit = 10M }
//    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
//    test <@ upgradedCustomer.Credit = 110M @>

//[<Fact>]
//let ``2-4 Increase max credit using vip``() =
//    let customer = { Id = 2; IsVip = true; Credit = 0M }
//    let upgradedCustomer = increaseCreditUsingVip customer
//    test <@ upgradedCustomer.Credit = 100M @>

//[<Fact>]
//let ``2-5 Upgrade customer with even id``() =
//    let customer = { Id = 2; IsVip = false; Credit = 0M }
//    let upgradedCustomer = upgradeCustomer customer
//    test <@ upgradedCustomer.IsVip = true && upgradedCustomer.Credit = 100M @>

//[<Fact>]
//let ``2-6 Upgrade customer with odd id``() =
//    let customer = { Id = 1; IsVip = false; Credit = 0M }
//    let upgradedCustomer = upgradeCustomer customer
//    test <@ upgradedCustomer.IsVip = false && upgradedCustomer.Credit = 50M @>




let customer = {
    Id = 1
    IsVip = false
    Credit = 0M<USD>
    PersonalDetails = Some {
        FirstName = "John"
        LastName = "Doe"
        DOB = DateTime(1970, 11, 23) }
    Notifications = ReceiveNotifications(receiveDeals = true,
                                         receiveAlerts = true)
}

[<Fact>]
let ``3-1 Create customer``() =
    test <@ customer.GetType() = typeof<Customer> @>

[<Fact>]
let ``3-2 Increase credit using USD``() =
    let upgradedCustomer = increaseCreditUsingVip customer
    test <@ upgradedCustomer.Credit = 50M<USD> @>
//
//[<Fact>]
//let ``3-3 Adult customer``() =
//    test <@ customer |> isAdult @>
//
//[<Fact>]
//let ``3-4 Non-adult customer``() =
//    let nonadult = { customer with PersonalDetails = Some { customer.PersonalDetails.Value with DateOfBirth = DateTime.Now.AddYears(-1) } }
//    test <@ not (nonadult |> isAdult) @>
//
//[<Fact>]
//let ``3-5 Customer without personal details``() =
//    let nonadult = { customer with PersonalDetails = None }
//    test <@ not (nonadult |> isAdult) @>
//
//[<Fact>]
//let ``3-6 Get alert when nofications are enabled``() =
//    let alert = customer |> getAlert
//    test <@ alert = "Alert for customer 1" @>
//
//[<Fact>]
//let ``3-7 Do not get alert when nofications are disabled``() =
//    let alert = { customer with Notifications = NoNotifications } |> getAlert
//    test <@ alert = "" @>
#load "Types.fs"
#load "Functions.fs"

open Types
open Functions

let customer = { Id = 1; IsVip = false; Credit = 10M }
let purchases = (customer, 101M)
let vipCustomer = tryPromoteToVip purchases

let customerWithMoreCredit = increaseCreditUsingVip customer

let z = upgradeCustomer customer

[<Measure>] type m
[<Measure>] type km
[<Measure>] type h
let distanceInM = 121.0<m>
let distanceInKm = 23.0<km>

let km2m (v:float<km>) = v * 1000.0<m/km>

let x = km2m distanceInKm + distanceInM



let time = 2.4<h>
let distance = 87.34<km>
let vivi = distance/time

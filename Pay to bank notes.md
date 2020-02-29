Pay to bank notes
=================

- Need to discuss amount/currency and destination/source amount currency. Understand the goal is to be able to specify a payout in the destination currency or in the source currency i.e.
  1. Send 100 GBP from a GBP currency account to USD, or
  2. Send 100 USD from a GBP curency account to USD

It should not be necessary to specify the source currency as this will always be the currency associated with the currency account.

Scenario 1: Same source and destination currency

{
    "amount": 10000,
    "currency": "GBP"
    "source": {
        "type": "currency_account",
        "id": "ca_xxx"
    },
    "destination": {
        "type": "bank_account",
        "account_number": "032180000118359719",
        "SWIFT": "BNMXMXMM",
        "first_name": "Juan",
        "last_name": "Smith",
        "country": "MX"
    }
}

Scenario 2: Different payout currency, amount in source currency

{
    "amount": 10000,
    "currency": "GBP",
    "source": {
        "type": "currency_account",
        "id": "ca_xxx" // GBP account
    },
    "destination": {
        "type": "bank_account",
        "currency": "USD",
        "account_number": "032180000118359719",
        "SWIFT": "BNMXMXMM",
        "first_name": "Juan",
        "last_name": "Smith",
        "country": "MX"
    }
}

Scenario 3: Different payout currency, amount in destination currency

{
    "amount": 10000,
    "currency": "USD",
    "source": {
        "type": "currency_account",
        "id": "ca_xxx" // GBP account
    },
    "destination": {
        "type": "bank_account",
        "account_number": "032180000118359719",
        "SWIFT": "BNMXMXMM",
        "first_name": "Juan",
        "last_name": "Smith",
        "country": "MX"
    }
}

In short, the root `currency` field is always the destination currency unless a `destination.currency` is provided. This allows for conversions.

- Seems like much of the details in the destination are really `recipient` fields. Perhaps we should move them there although we need to decide what gets stored in the Vault instrument alongside the bank details.

- Destination reference - this is what appears on the recipient's statement. Should this not be included in billing descriptor?
- For sender, how do we differentiate the required fields for AFTs vs Bank account?
- What is the purpose of sender reference? Why is this required? In general, discussion around references for bank payouts
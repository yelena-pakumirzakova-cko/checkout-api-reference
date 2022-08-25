// For more information please refer to https://github.com/checkout/checkout-sdk-net
using Checkout.Payments.Hosted;

ICheckoutApi api = CheckoutSdk.Builder().StaticKeys()
    .SecretKey("secret_key")
    .Environment(Environment.Sandbox)
    .HttpClientFactory(new DefaultHttpClientFactory())
    .Build();

try
{
    HostedPaymentDetailsResponse response = await api.HostedPaymentsClient().GetHostedPaymentsPageDetails("hosted_payment_id");
}
catch (CheckoutApiException e)
{
    // API error
    string requestId = e.RequestId;
    var statusCode = e.HttpStatusCode;
    IDictionary<string, object> errorDetails = e.ErrorDetails;
}
catch (CheckoutArgumentException e)
{
    // Bad arguments
}
catch (CheckoutAuthorizationException e)
{
    // Invalid authorization
}
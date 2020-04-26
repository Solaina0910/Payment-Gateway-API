# Payment-Gateway-API
Please note that I have not been able to deploy the application with Docker.

## Process Payment

The payment gateway enables a merchant to process a payment. Below are the fields that the merchant should fill up to process the payment.

|Fields	        |Mandatory	   |Description
| :--- | :--- | :--- |
|Card Type	    |Yes	       |The type of the payment card.
|Name On Card	|Yes	       |The name of the shopper as it is displayed on the payment card.
|Card Number	|Yes	       |The 12 digits number printed on the front of payment card.
|Expiry Month	|Yes	       |The payment card expiry month.
|Expiry Year	|Yes	       |Integer >= 0, The payment card expiry year                           
|CVV	        |Yes	       |The 3 digits code printed on the back of the card.
|Currency	    |Yes	       |The currency used for the purchase. 
|Amount	        |Yes	       |Integer >= 0, The amount of the purchase.                           
|Merchant	    |Yes	       |The seller of the product.
|Bank	        |Yes	       |The acquiring bank.

## Bank Response
When the merchant submits a transaction via the payment gateway, the request is forwarded to the acquiring bank and a response is received from the bank. Below are test details to simulate a bank response.

|Validation	                                                |Bank Response 	         |Test Data
| :--- | :--- | :--- |
Check if CVV is a 3 digits number 	                        |Security Breach	     |CVV: 1234
|Check if Amount is less than or equal to 100000	        |Not enough fund	     |Amount: 300000
|Check if Card Number is a 12 digits number	                |Invalid Card Number	 |Card Number: 1111
|Check if the Card Expiry Date greater than Today’s date.	|Card has expired	     |Year: 2015


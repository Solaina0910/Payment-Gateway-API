# Payment-Gateway-API
Kindly note that I have not been able to deploy the application with Docker.

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
|Amount	      |Yes	       |Integer >= 0, The amount of the purchase.                           
|Merchant Id	|Yes	       |The Id of the seller of the product.
|Bank	Id      |Yes	       |The Id of the acquiring bank.

## Test Bank

|Id	    |Name	       |Active
| :--- | :--- | :--- |
|2	    |Test Bank 1   |1
|1002	|Test Bank 2   |1
|1003	|Test Bank 3   |1

## Test Merchant
|Id	                                    |Name	     |Active
| :--- | :--- | :--- |
|252C3DE3-7897-4DEA-F50E-08D7E93FD57C	|Ebay	     |1
|3FA85F64-5717-4562-B3FC-2C963F66AFA6	|Alibaba	 |1
|BC512D99-DC33-49BC-A328-F6C768E0D6A1	|Amazon	     |1

## Details of a Transaction

|Id	                 |583B3DB7-98E8-467A-0262-08D7E9E82F00	
| :--- | :--- |	
|MerchantId          |BC512D99-DC33-49BC-A328-F6C768E0D6A1
|BankId	             |2	
|Currency	         |MUR	
|CardType	         |MasterCard			
|CardNumber	         |111122223333
|NameOnCard	         |Tester
|ExpiryMonth	     |7 
|ExpiryYear          |2050	
|CVV	             |111
|Amount	             |10000
|BankResponse        |Successful	
|BankResponseId	     |04F99D39-A1DA-41CE-BBFC-2FE28F0AFCAF
|Status              |Successful

## Bank Response
When the merchant submits a transaction via the payment gateway, the request is forwarded to the acquiring bank and a response is received from the bank. Below are test details to simulate a bank response.

|Validation	                                                |Bank Response 	         |Test Data
| :--- | :--- | :--- |
Check if CVV is a 3 digits number 	                        |Security Breach	     |CVV: 1234
|Check if Amount is less than or equal to 100000	        |Not enough fund	     |Amount: 300000
|Check if Card Number is a 12 digits number	                |Invalid Card Number	 |Card Number: 1111
|Check if the Card Expiry Date greater than Today’s date.	|Card has expired	     |Year: 2015


# DICOM Security Testing Tool

## Overview

The tool is designed to perform testing on the applications which supports DICOM Network Communication.

The testing process begins with scanning the network, detecting the open/filtered ports if any. Once an open port is detected, we use DIMSE-C Service and send C-ECHO request to the machine whose IP address and port on which application listens for DICOM Messages to check if we get a successful response upon which we try to Query patient information and save it to local system.

These Patient details can be used to further retrieve the .dcm files, using the results of study ID found in the earlier Queries.

If the C-ECHO Fails due to the implementation of SSL/TLS we check for the version of SSL/TLS and the cipher suites supported, which would be compared to the DICOM standards that NEMA proposed.

![](https://user-images.githubusercontent.com/50069880/58115648-226ae180-7c18-11e9-9b94-67c050efb525.png)

_Figure: Tool UI_

## Tool Working

The tool has total 3 modules:

1. Scan
2. Basic Tests
3. SSL Test

### Scan

This module scans the network to determine if the given port is open/filtered or closed.

User enters the IP address or the subnet, which would be scanned against the port given by user and determines if the port on which the application listens for DICOM Messages is open or closed.

The results are shown containing the service name and status in a window.

User can also keep the port as blank, in which case the application scans for all 65535 ports and writes them into a file saying which all port are open and which service&#39;s are running in them.

![](https://user-images.githubusercontent.com/50069880/58115647-21d24b00-7c18-11e9-8c78-7a3cbd671a83.png)

_Figure: Entering Configuration details._

![](https://user-images.githubusercontent.com/50069880/58115646-21d24b00-7c18-11e9-87b2-135ee7d339b2.png)

_Figure: Scan Initiated._

![](https://user-images.githubusercontent.com/50069880/58115643-2139b480-7c18-11e9-87c8-9b71ff5cbb11.png)

_Figure: Scan Results._

### Basic Tests

This module performs basic DICOM C-ECHO Message and checks for the response, which upon success tries to query the patient details and writes into a file on local system.

If the C-ECHO Messages are failed due to the implementation of SSL/TLS then the test stops for querying patient info and proceeds to check for SSL/TLS test.


![](https://user-images.githubusercontent.com/50069880/58115641-2139b480-7c18-11e9-93b5-5b43e5c7cb81.png)

_Figure: Basic Tests_

![](https://user-images.githubusercontent.com/50069880/58115639-2139b480-7c18-11e9-8f22-2debffbb518f.png)

_Figure: C-Echo success as the SSL/TLS over DICOM communication is not implemented._

![](https://user-images.githubusercontent.com/50069880/58115638-20a11e00-7c18-11e9-85c0-8d6bec33c1e0.png)

_Figure: Dumping patient details into File in local system._

### SSL Test

This module tests to determine the version of SSL/TLS used, also find the list of cipher suites supported by the application which is listening for DICOM Messages.

It then compares the result with the DICOM Standards, which do not allow any TLS version below 1.2 and the list of cipher suites supported as defined in [http://dicom.nema.org/medical/dicom/current/output/html/part15.html](http://dicom.nema.org/medical/dicom/current/output/html/part15.html).

If the Standards does not meet the tool outputs message saying the standards are not met, erstwhile with a success Message.

![](https://user-images.githubusercontent.com/50069880/58115636-20a11e00-7c18-11e9-80d4-ea676684886f.png)

_Figure: Performing SSL Scan on the application listening over Secure DICOM Port._

![](https://user-images.githubusercontent.com/50069880/58115635-20a11e00-7c18-11e9-9516-345478af5d99.png)

_Figure: Displaying the List of cipher suites supported by DICOM Standard._

![](https://user-images.githubusercontent.com/50069880/58115634-20088780-7c18-11e9-84a3-949530cdf88b.png)

_Figure: Displaying the List of cipher suites detected._



## Auto Scan

This module covers all the above three mentioned above into a single one, and results are written into a Log. No user interaction is needed once clicked on autos can it covers all the three phases and publishes the results.


![](https://user-images.githubusercontent.com/50069880/58115633-20088780-7c18-11e9-9f96-098d183dc273.png)

_Figure: Auto scan initiated._

![](https://user-images.githubusercontent.com/50069880/58115632-20088780-7c18-11e9-8762-f7a32771ad16.png)

_Figure: Auto scan completed port scan detection._

![](https://user-images.githubusercontent.com/50069880/58115631-1f6ff100-7c18-11e9-9865-4fdf90747a37.png)

_Figure: Auto scan performing Basic DICOM Tests._

![](https://user-images.githubusercontent.com/50069880/58115630-1f6ff100-7c18-11e9-9999-a81c54e012fb.png)

_Figure: Tool Determining the Status of DICOM Tests conducted._

![](https://user-images.githubusercontent.com/50069880/58115629-1f6ff100-7c18-11e9-9a4d-3c77fc9daf78.png)

_Figure: Test completed with Results saved in Log._

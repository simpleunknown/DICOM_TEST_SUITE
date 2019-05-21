# DICOM Security Testing Tool

## Overview

The tool is designed to perform testing on the applications which supports DICOM Network Communication.

The testing process begins with scanning the network, detecting the open/filtered ports if any. Once an open port is detected, we use DIMSE-C Service and send C-ECHO request to the machine whose IP address and port on which application listens for DICOM Messages to check if we get a successful response upon which we try to Query patient information and save it to local system.

These Patient details can be used to further retrieve the .dcm files, using the results of study ID found in the earlier Queries.

If the C-ECHO Fails due to the implementation of SSL/TLS we check for the version of SSL/TLS and the cipher suites supported, which would be compared to the DICOM standards that NEMA proposed.

![](https://drive.google.com/open?id=1Funh1j3gGPsznpQt2hd7EMnp1m7DSOcF)
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

![](https://drive.google.com/open?id=1P5Eh3ZPsJCTp9z0MmfxLKCti1TIOpVKO)
_Figure: Entering Configuration details._

![](https://drive.google.com/open?id=1B98cLeTTeFVkCJPNI34ZfNre3Ah-TTKx)
_Figure: Scan Initiated._

![](https://drive.google.com/open?id=1nUv8PDs463Qbv4ttooayDfCDt33hmTtk)
_Figure: Scan Results._

### Basic Tests

This module performs basic DICOM C-ECHO Message and checks for the response, which upon success tries to query the patient details and writes into a file on local system.

If the C-ECHO Messages are failed due to the implementation of SSL/TLS then the test stops for querying patient info and proceeds to check for SSL/TLS test.


![](https://drive.google.com/open?id=1DAf-wzcp3B2rzPbQrU-ZPciemuAVKKr6)
_Figure: Basic Tests_

![](https://drive.google.com/open?id=1SRCpCEaaOPOpWXD3tOZO9DLYUUYkInVN)
_Figure: C-Echo success as the SSL/TLS over DICOM communication is not implemented._

![](https://drive.google.com/open?id=1FUklCOWux1aCMbRw48I-fwlh628SZ67m)
_Figure: Dumping patient details into File in local system._

### SSL Test

This module tests to determine the version of SSL/TLS used, also find the list of cipher suites supported by the application which is listening for DICOM Messages.

It then compares the result with the DICOM Standards, which do not allow any TLS version below 1.2 and the list of cipher suites supported as defined in [http://dicom.nema.org/medical/dicom/current/output/html/part15.html](http://dicom.nema.org/medical/dicom/current/output/html/part15.html).

If the Standards does not meet the tool outputs message saying the standards are not met, erstwhile with a success Message.

![](https://drive.google.com/open?id=1ASrxS6g95crhv3C9ychBX_ywkUf5csCF)
_Figure: Performing SSL Scan on the application listening over Secure DICOM Port._

![](https://drive.google.com/open?id=1T0Cfci_gICw3ntZDh4fXdsLGu8CTmL5v)
_Figure: Displaying the List of cipher suites supported by DICOM Standard._

![](https://drive.google.com/open?id=1pd0tOT5oIA9SzSF2j0u4PxMCkbJcTUJt)
_Figure: Displaying the List of cipher suites detected._



## Auto Scan

This module covers all the above three mentioned above into a single one, and results are written into a Log. No user interaction is needed once clicked on autos can it covers all the three phases and publishes the results.


![](https://drive.google.com/open?id=1fCvqlHR1nJPpOTaPznCOBBQ6ZVa6zSha)
_Figure: Auto scan initiated._

![](https://drive.google.com/open?id=1k7Vqn5snA3k0y0RvvMDR7EYEEhoWLN1Z)
_Figure: Auto scan completed port scan detection._
![](https://drive.google.com/open?id=1TJs12CLw5U6n4J0TkX85KI2Os4I9vmvE)
_Figure: Auto scan performing Basic DICOM Tests._
![](https://drive.google.com/open?id=1_dJO1CzrnhWPJ1pH6jEcUtd0cfjgpv_q)
_Figure: Tool Determining the Status of DICOM Tests conducted._
![](https://drive.google.com/open?id=1FeegRy_J1wHIlwk1Sqvm1W2vfV0VB4NN)
_Figure: Test completed with Results saved in Log._

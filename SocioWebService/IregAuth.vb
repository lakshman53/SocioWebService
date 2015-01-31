Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IregAuth" in both code and config file together.
<ServiceContract()>
Public Interface IregAuth

    <OperationContract()>
    Sub DoWork()

End Interface

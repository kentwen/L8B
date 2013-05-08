Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class clsSECSHead
    Dim mvarPType As Byte
    Dim mvarSType As Byte
    Dim mvarDeviceID As UInteger
    Dim mvarStream As Byte
    Dim mvarFunction As Byte
    Dim mvarWaitBit As Boolean
    Dim mvarSystemByte As ULong
    Dim mvarHeaderByte As String

    Public Sub SECSHead()
        mvarPType = 0
        mvarSType = 0
        mvarDeviceID = 0
        mvarStream = 0
        mvarFunction = 0
        mvarWaitBit = False
        mvarSystemByte = 0
    End Sub

    Public Property PType() As Byte
        Get
            PType = mvarPType
        End Get
        Set(ByVal value As Byte)
            mvarPType = value
        End Set
    End Property

    Public Property SType() As Byte
        Get
            SType = mvarSType
        End Get
        Set(ByVal value As Byte)
            mvarSType = value
        End Set
    End Property

    Public Property DeviceID() As UInteger
        Get
            DeviceID = mvarDeviceID
        End Get
        Set(ByVal value As UInteger)
            mvarDeviceID = value
        End Set
    End Property

    Public Property StreamID() As Byte
        Get
            StreamID = mvarStream
        End Get
        Set(ByVal value As Byte)
            mvarStream = value
        End Set
    End Property

    Public Property FunctionID() As Byte
        Get
            FunctionID = mvarFunction
        End Get
        Set(ByVal value As Byte)
            mvarFunction = value
        End Set
    End Property

    Public Property WaitBit() As Boolean
        Get
            WaitBit = mvarWaitBit
        End Get
        Set(ByVal value As Boolean)
            mvarWaitBit = value
        End Set
    End Property

    Public Property SystemByte() As ULong
        Get
            SystemByte = mvarSystemByte
        End Get
        Set(ByVal value As ULong)
            mvarSystemByte = value
        End Set
    End Property

    Public Property HeaderByte() As String
        Get
            HeaderByte = mvarHeaderByte
        End Get
        Set(ByVal value As String)
            mvarHeaderByte = value
        End Set
    End Property
End Class

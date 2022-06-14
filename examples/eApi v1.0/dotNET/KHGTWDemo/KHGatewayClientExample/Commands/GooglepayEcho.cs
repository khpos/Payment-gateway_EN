﻿using KHGatewayClientExample.Common;
using KHGatewayClientExample.Communication;
using KHGatewayClientExample.Security;
using ManyConsole;
using NLog;

namespace KHGatewayClientExample.Commands;

public class GooglepayEcho : ConsoleCommand
{
    private readonly Logger _log = LogManager.GetCurrentClassLogger();

    public GooglepayEcho()
    {
        IsCommand("GOOGLEPAY_ECHO", "Performs GOOGLEPAY_ECHO operation.");
    }

    public override int Run(string[] remainingArguments)
    {
        var crypto = new Crypto(Constants.MerchantId, Constants.MerchantKeyFileName, Constants.MipsPublicKey);
        var client = new MipsConnector(crypto);
        var result = client.GooglepayEcho();
        _log.Info("result code: {}, result message: {}", result.ResultCode, result.ResultMessage);
        return 0;
    }
}
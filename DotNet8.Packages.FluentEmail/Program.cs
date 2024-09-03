﻿using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        var fromEmail = "lth1212001@gmail.com";
        var toEmail = "soniapoudel03@gmail.com";
        var subject = "Fluent Email Sample";

        Console.WriteLine("Body: ");
        string body = Console.ReadLine()!;

        serviceCollection.AddFluentEmail(fromEmail).AddSmtpSender("smtp.gmail.com", 587, fromEmail, "wqxk dptz rfgm hjjf");
        var services = serviceCollection.BuildServiceProvider();

        var fluentEmail = services.GetRequiredService<IFluentEmail>();
        var response = await fluentEmail.To(toEmail).Subject(subject).Body(body).SendAsync();

        Console.WriteLine("Message was sent => " + response.Successful);
        Console.ReadLine();
    }
}
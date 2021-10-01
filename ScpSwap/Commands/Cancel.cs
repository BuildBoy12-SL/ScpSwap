﻿// -----------------------------------------------------------------------
// <copyright file="Cancel.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ScpSwap.Commands
{
    using System;
    using CommandSystem;
    using Exiled.API.Features;
    using ScpSwap.Models;

    /// <summary>
    /// Cancels an active swap request.
    /// </summary>
    public class Cancel : ICommand
    {
        /// <inheritdoc />
        public string Command { get; } = "cancel";

        /// <inheritdoc />
        public string[] Aliases { get; } = Array.Empty<string>();

        /// <inheritdoc />
        public string Description { get; } = "Cancels an active swap request.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player playerSender = Player.Get(sender);
            Swap swap = Swap.FromSender(playerSender);
            if (swap == null)
            {
                response = "You do not have an active swap request.";
                return false;
            }

            swap.Cancel();
            response = "Swap request cancelled!";
            return true;
        }
    }
}
// <copyright file="GlobalSuppressions.cs" company="Koji Natsuhara (ID: 11666900)">
// Copyright (c) Koji Natsuhara (ID: 11666900). All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Was told to make the variable protected instead of private.>", Scope = "member", Target = "~F:CptS321.SpreadsheetCell.text")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Was told to make the variable protected instead of private.>", Scope = "member", Target = "~F:CptS321.SpreadsheetCell.value")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1130:Use lambda syntax", Justification = "<Want to keep it delegate {} as Venera shows in her examples>", Scope = "member", Target = "~E:CptS321.SpreadsheetCell.PropertyChanged")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1130:Use lambda syntax", Justification = "<Want to keep the format that Venera has in her examples>", Scope = "member", Target = "~E:CptS321.SpreadsheetCellValue.PropertyChanged")]

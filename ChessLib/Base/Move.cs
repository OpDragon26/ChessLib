using System.Diagnostics.CodeAnalysis;
using ChessLib.API.Display;
using ChessLib.API.Display.Formatting;
using ChessLib.API.Generic;
using ChessLib.API.Parsing;
using ChessLib.Utils;

namespace ChessLib.Base;

public readonly struct Move(int source, int target, byte promotion = 0, Flag flag = Flag.None)
{
    public readonly int Source = source;
    public readonly int Target = target;
    public readonly byte Promotion = promotion;
    public readonly Flag Flag = flag;

    public bool IsPromotion => Promotion != 0;

    public Move(Coordinate source, Coordinate target, byte promotion = 0, Flag flag = Flag.None)
        : this(source.AsIndex(), target.AsIndex(), promotion, flag) {}

    public Move(string source, string target, byte promotion = 0, Flag flag = Flag.None)
        : this(source.ParseSquare().AsIndex(), target.ParseSquare().AsIndex(), promotion, flag) {}

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is null)
            return false;

        Move other = (Move)obj;

        return other.Source == Source
               && other.Target == Target
               && other.Promotion == Promotion
               && other.Flag == Flag;
    }

    public override int GetHashCode()
    {
        int hash = 0;

        hash |= Source;
        hash |= Target << 6;
        hash |= Promotion << 12;
        hash |= (int)Flag << 16;

        return hash;
    }

    public override string ToString()
    {
        return Source.ToAlgebraic() + Target.ToAlgebraic() + DefaultFormatting.ASCII.FormatPiece(promotion);
    }
}

public enum Flag : byte
{
    None,
    DoublePawn,
    EnPassant,
    ShortCastle,
    LongCastle,
}
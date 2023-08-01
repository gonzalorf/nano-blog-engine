﻿using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Domain.Posts;

public class Rate
{
    private Rate() { }

    internal Rate(RateId id, int value, User? rater)
    {
        Id = id;
        Value = value;
        Rater = rater;
    }

    public RateId Id { get; private set; }
    public int Value { get; private set; }
    public User? Rater { get; private set; }
}
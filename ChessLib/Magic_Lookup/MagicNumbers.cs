namespace ChessLib.Magic_Lookup;

/// <summary>
/// Contains the information required to perform magic lookup
/// </summary>
public static class MagicNumbers
{
    public static readonly MagicNumber[] Rook =
    [
        new(0x4addb78708aa0b9f, 48, 65533), new(0x17617fdb743430c0, 48, 65534), new(0x5730d9c5d0b7a099, 48, 65533),
        new(0x6128d1644a19da90, 48, 65535), new(0x324f2db0d0f7ea68, 48, 65534), new(0x59000019d8d12ab1, 48, 65524),
        new(0x3900007dcf6f69ff, 48, 65532), new(0x64ffbf94b6a40e9f, 48, 65523), new(0x305e8ba49802bf61, 48, 65534),
        new(0x7c27c8a8d7551740, 48, 65534), new(0x3cf3e3b088bdf713, 48, 65532), new(0x7d7faff0600f3fd0, 48, 65533),
        new(0x1872c40075fd67b4, 48, 65527), new(0x3947efff2050180c, 48, 65534), new(0x41abb2fffafa204d, 48, 65535),
        new(0x418ee5b9214da087, 48, 65535), new(0x7cbf09502ad5be57, 48, 65535), new(0x2c77ec8659ab4012, 48, 65528),
        new(0x13a9668dca9a9820, 48, 65533), new(0x2f25d5170a1d0cf0, 48, 65535), new(0x70605554fa65865d, 48, 65535),
        new(0x6753085400ff27ac, 48, 65532), new(0x1bc4c822740a28d2, 48, 65532), new(0xa592d8751723e9, 48, 65533),
        new(0x601627e04731c68b, 48, 65534), new(0x24537ae1ecca94cc, 48, 65531), new(0x63e04eccaaaae3ce, 48, 65535),
        new(0x6a153a00013d686, 48, 65528), new(0xc7cab8d00002545, 48, 65531), new(0x791f0b5f34cd0bf4, 48, 65535),
        new(0x655ba6758a74ef3e, 48, 65532), new(0x2e1ecc155d9e5f01, 48, 65534), new(0x2ce3934b7a88a242, 48, 65533),
        new(0x1de80a659effff4b, 48, 65535), new(0x2bcbf21e90cccc54, 48, 65533), new(0xcf34b041be41b68, 48, 65534),
        new(0x23b9ec3f807f8055, 48, 65534), new(0x55609cc03ec80234, 48, 65529), new(0x7e6d3b5ae097340a, 48, 65535),
        new(0x6fe96de52859dd8d, 48, 65534), new(0x6f4ab9e46abf2a84, 48, 65528), new(0x530a9d1131dd5558, 48, 65529),
        new(0x4cdf73c204188a20, 48, 65534), new(0x52d2148c5b86f094, 48, 65534), new(0x36433363a104f12c, 48, 65527),
        new(0x4cd79d5bbd3bfc04, 48, 65530), new(0x79ddfb2f94577936, 48, 65535), new(0x665f93c35e7be1, 48, 65534),
        new(0x62cb5b0965140ea9, 48, 65523), new(0x4aed402a3524d440, 48, 65535), new(0x190c4e0884404320, 48, 65517),
        new(0x5afc308ae45aef10, 48, 65529), new(0x5fcdd09a971c1041, 48, 65536), new(0x3333fc90312be094, 48, 65534),
        new(0x5d2b6a45467996fa, 48, 65531), new(0x4d4b23d217b12b9b, 48, 65535), new(0x3e9ba88650c2ef51, 48, 65530),
        new(0x68b909d95006d599, 48, 65535), new(0x245b277c00b6af7d, 48, 65527), new(0x5fdee1d2d2d256a1, 48, 65528),
        new(0x36927c76df90104b, 48, 65535), new(0x227993ffaa438fa1, 48, 65526), new(0x3b40102be0605a25, 48, 65533),
        new(0x9f09428aa78597a, 48, 65535)
    ];

    public static readonly MagicNumber[] Bishop =
    [
        new(0x378bec8eedc03161, 56, 255), new(0x1a8cd5ea20b2ef7c, 56, 256), new(0xff1b39332d24345, 56, 255),
        new(0xb1f40341e32319c, 56, 256), new(0x26a300403425b510, 56, 252), new(0x1cc4f5e56ab24c9b, 55, 510),
        new(0x786d35d95c0a9568, 56, 256), new(0x76fba42085769dc2, 56, 256), new(0x8c7bb3d5d7059e, 56, 256),
        new(0xfbb8bad14fb8fc3, 53, 2044), new(0x22debe6f40e2a6d2, 53, 2047), new(0x682eb548d5a1d627, 52, 4095),
        new(0x60baa05d8191f391, 53, 2047), new(0x5d135973c7149e93, 53, 2047), new(0x6a22990072386392, 53, 2046),
        new(0x4f9bac44455c01e0, 55, 511), new(0x50a40e1b0f232894, 56, 256), new(0x4e88d8cbbd27e916, 53, 2044),
        new(0x45c05911f8d63887, 50, 16382), new(0x7e931302a5edfd00, 50, 16383), new(0x5d594044dcc66bee, 50, 16383),
        new(0x799001b11ebff2d1, 50, 16378), new(0x6bbe11642c1b02c6, 53, 2046), new(0x2c7f0711dd8fb54, 56, 255),
        new(0x7f61c2cbcb91a1c2, 55, 508), new(0x2471022a28f7540c, 53, 2035), new(0x37b8bd02c2480aae, 50, 16379),
        new(0x5b0de1abe1e826c7, 48, 65535), new(0x54e9ac99b6840680, 48, 65534), new(0x4080661b66d6e03, 50, 16383),
        new(0x2c900c181e560ad7, 53, 2029), new(0x77c847f8752f0042, 56, 255), new(0x1d1e7ef3cbbfff3a, 56, 254),
        new(0x329d029c99a73b0d, 53, 2047), new(0x3fde55b2bc60010c, 51, 8183), new(0x7c643124860d8f86, 48, 65530),
        new(0x5ffdb70b74fe174b, 48, 65531), new(0x2ac1216e7ab6327a, 50, 16376), new(0x7fb72c5214890a42, 53, 2047),
        new(0x33a82829efcff601, 56, 255), new(0x7c86085fff1cafbe, 56, 255), new(0x295a5fdd59420153, 53, 2046),
        new(0x241ce4a8a76bf628, 50, 16352), new(0x493ff8019b3999fd, 50, 16382), new(0x2118c61fa7e86fae, 50, 16372),
        new(0x2ac0b2880bbffb41, 51, 8191), new(0x3b801d17497ff378, 53, 2047), new(0x56d18ad1fd9a3374, 56, 254),
        new(0x187b7edb3785e912, 56, 254), new(0x3078cbd923155ce1, 53, 2047), new(0xd8f6dc10a969710, 53, 2044),
        new(0x5fbef4c1babd0aa8, 53, 2045), new(0x55cc647e0b7affe6, 53, 2043), new(0xb4c651470019fa3, 53, 2043),
        new(0x3da602e55a59546d, 54, 1023), new(0x46f08c8a83888022, 56, 255), new(0x35e80732c668c6bf, 56, 249),
        new(0x4314a316e94b6e87, 56, 255), new(0x632d10880402ef2f, 56, 254), new(0x26a5799544ed7579, 56, 255),
        new(0x2f66d18770f3c313, 56, 252), new(0x4a1d2eaf17e5040b, 56, 255), new(0x2a8a0d815aafd1d8, 56, 256),
        new(0x378514b22abebfb0, 56, 255)
    ];

    public static readonly MagicNumber[] Knight =
    [
        new(0x52e4e625a0cfe386, 62, 4), new(0x7f0db68c00331802, 61, 8), new(0x714b104fae44a291, 60, 16),
        new(0x77430c40f7119219, 60, 16), new(0x2811c431e70f2632, 60, 16), new(0x7ccf819c65142bf8, 60, 16),
        new(0x21a4c31a242dcf08, 61, 8), new(0x2f946d3a615c4b1e, 62, 4), new(0x194d7043db0cc374, 61, 8),
        new(0x3894f620f69d1c61, 60, 16), new(0xace58204efddcfa, 57, 126), new(0x763c527cc26360d3, 57, 126),
        new(0x3ba7327ebff1fb89, 57, 123), new(0xc284101053566dc, 58, 64), new(0x2c0e8f550a02f7e1, 60, 16),
        new(0xcb6617ecd8ad3ad, 61, 8), new(0x24b814cdbcdff1ae, 60, 16), new(0x103302a3a024d5f8, 58, 64),
        new(0x2808024607803f68, 56, 256), new(0x617a1e458a74061c, 55, 511), new(0x12aacb4959589730, 55, 512),
        new(0x3b5557bfefab457b, 55, 511), new(0x277e8a2800f960e4, 57, 127), new(0x5846505f02077412, 60, 16),
        new(0x2bcd25a8e3131fa, 60, 16), new(0x6f205ccc7df34b4d, 57, 126), new(0x6febde092035e916, 55, 511),
        new(0x229800424d8c0524, 55, 507), new(0x58f401c035004397, 56, 256), new(0x27141c794138391c, 55, 509),
        new(0x4b64e04095007283, 57, 128), new(0x3e98d39145ca7a7b, 60, 16), new(0x5ebd08217be861dd, 60, 16),
        new(0x1b58f03040958816, 58, 64), new(0x539ff00400307300, 56, 256), new(0x5e68fc04009b0110, 56, 256),
        new(0xfa07400fbcb103e, 55, 509), new(0x12cc8c0b00318018, 55, 479), new(0x46672665cb6be04, 57, 123),
        new(0x3bfcb87c5b41506, 60, 16), new(0x50899e4388cf90e9, 60, 16), new(0x18b6bd205e93c910, 58, 64),
        new(0x145446701401c901, 56, 256), new(0x1e7ee54244001f04, 56, 256), new(0x2937767201205b84, 56, 256),
        new(0x1b8bbf9b01040c86, 56, 256), new(0x3631d422818c07db, 58, 64), new(0xb15977e1910249f, 60, 16),
        new(0x6128f73656a5322, 61, 8), new(0x5abb6c67c49c0f90, 60, 16), new(0x6c8b269a141c1181, 58, 64),
        new(0x62cc96254c0c01ab, 58, 64), new(0x1e371c7e9e038042, 58, 64), new(0xea66dfcf100c241, 58, 64),
        new(0x7fcf73f8070f04f4, 60, 16), new(0x69ccc89faa420009, 61, 8), new(0x16965dfd8ec09ed5, 62, 4),
        new(0x2c59276dbd6168ae, 61, 8), new(0x1fb4511a75882839, 60, 16), new(0x45e0ce7d69941410, 60, 16),
        new(0xb12402a01d1c678, 60, 16), new(0x571e57ec5f5a2822, 60, 16), new(0x18f50bfad5770574, 61, 8),
        new(0x73207771f70374de, 62, 4)
    ];

    public static readonly MagicNumber[] King =
    [
        new(0x2190426a82ba40ec, 61, 8), new(0x4c60107336b73ec1, 59, 32), new(0x5e3016382eb59217, 59, 32),
        new(0x130819762e7d82f9, 59, 32), new(0xd8c07853e767c03, 59, 32), new(0x1f22002df57bb089, 59, 32),
        new(0x56e30028ff058fee, 59, 32), new(0x648129714353cf4c, 61, 8), new(0x38c160ed36770875, 59, 32),
        new(0x605b34fa8b0e2e4b, 55, 511), new(0x424dac088f3a10, 55, 492), new(0x58018b0006518357, 55, 510),
        new(0x19501cc20e85eee3, 55, 512), new(0x55b4b6eaa2bf10d4, 55, 510), new(0x4e62cc8905411e46, 55, 511),
        new(0x25a0910444d91d55, 59, 32), new(0x69d440602b10d66d, 59, 32), new(0x76aa7bd32e8f7d3e, 55, 511),
        new(0x34217160b9d09ed8, 55, 511), new(0x2ddf17d01a4f6b80, 55, 511), new(0x3bbc4250087afc36, 55, 510),
        new(0x1f8c883d747f41aa, 55, 511), new(0x6a7679baff7ddab4, 55, 511), new(0x2b7ed18100e96b54, 59, 32),
        new(0x6c15f89041b771c0, 59, 32), new(0x4e65ed434403cf1f, 55, 507), new(0x21cc7d46804e707f, 55, 510),
        new(0x436b2f97463340b, 55, 511), new(0x6e58f69c1b8cde8c, 55, 511), new(0x79a1841238db3285, 55, 511),
        new(0x4f28a0ad01348637, 55, 511), new(0x43009f0082660e4b, 59, 32), new(0xe83b8e0c1f8369b, 59, 32),
        new(0x553b4838f59a553d, 55, 511), new(0x45e37dde5f8fc762, 55, 509), new(0x7f70e5ff2f3834ff, 55, 510),
        new(0x615e756d6e70a681, 55, 511), new(0x1f214861e2aba011, 55, 511), new(0x1341d95546cead45, 55, 511),
        new(0x4a6dc37e1830263, 59, 32), new(0x7a7d3896766f3f1d, 59, 32), new(0x44ed281b20c9c85a, 55, 511),
        new(0x3d0e2bf15e4c1f0c, 55, 511), new(0x422171c8ba212ae5, 55, 511), new(0x228586134d30fc00, 55, 512),
        new(0x2a9252c10e157eac, 55, 512), new(0x6b4f80fcca683418, 55, 512), new(0x6c0f280b6d01e4c3, 59, 32),
        new(0x195763b029c17138, 59, 32), new(0xd0bdb72f70e0621, 55, 512), new(0x58b29580de4d81c7, 55, 512),
        new(0x23590eabd1f80263, 56, 256), new(0x59838523bd5d804c, 56, 256), new(0x6b97cd50bda5477a, 55, 511),
        new(0x2fb5cccacd90982f, 55, 511), new(0x66c5695ef027c0b5, 59, 32), new(0x561ab8e1e4e3927, 61, 8),
        new(0x7306791bbf46600c, 59, 32), new(0x4a8ce392517cf059, 59, 32), new(0x59f390e7cc22380b, 59, 32),
        new(0x4fed0464442a1884, 59, 32), new(0x11dfa7300461dc46, 59, 32), new(0x4a7983261dbe2a21, 59, 32),
        new(0x42f1b3083a80ea55, 61, 8)
    ];

    public static readonly MagicNumber[] Pawn =
    [
        new(0x59c0be88bf55a873, 61, 8), new(0x64a058c2a352653b, 60, 16), new(0x3e902d1296b8d774, 60, 16),
        new(0x3ca81bad3508167b, 60, 16), new(0x702db264106c0b78, 60, 16), new(0x4c721b06434a304, 60, 16),
        new(0x6e6a42a60e664e7e, 60, 16), new(0xd974b5d9cf71903, 61, 8), new(0x40c3102cc4872aa5, 59, 32),
        new(0x340c602d00454a0f, 57, 128), new(0x1000062281ed18af, 57, 128), new(0x3f013802c3a25b5d, 57, 128),
        new(0x7c82cc056143f468, 57, 128), new(0x8407a01f397364e, 57, 128), new(0x330058a1b80b2731, 57, 128),
        new(0x7e4235001826ec62, 59, 32), new(0x22f04a43f1363e9e, 60, 16), new(0x4c601c1466cf80d6, 58, 64),
        new(0x13b0124a24a1c9e3, 58, 64), new(0x4da8120304db9a11, 58, 64), new(0x56bc019f9083a59f, 58, 64),
        new(0x14cd45c601cbf6cf, 58, 64), new(0x5343228100fc59c1, 58, 64), new(0x2fecd1a1006f9674, 60, 16),
        new(0x55b4c2e8511d634d, 60, 16), new(0x40543430600250c8, 58, 64), new(0x61ee5e2c50065fc2, 58, 64),
        new(0xfe0a801e109c1ab, 58, 64), new(0x3e6c9e81141073b7, 58, 64), new(0x1befde02cdc0a5bf, 58, 64),
        new(0x59baa502b16024d2, 58, 64), new(0x5a4ac4873220f5ce, 60, 16), new(0x120b71c192f38416, 60, 16),
        new(0x457366e0315c4d64, 58, 64), new(0x1e3cb2ee3b9006a6, 58, 64), new(0x6fbb3860827409e9, 58, 64),
        new(0x70c3042d8d340412, 58, 64), new(0x5400af7e021dc251, 58, 64), new(0xf3f95d10106e113, 58, 64),
        new(0x87c8cf01704d1f, 60, 16), new(0x4fc9cb83c16350c5, 60, 16), new(0x6f4cdc17881d4104, 58, 64),
        new(0xc4e1c235004ba40, 58, 64), new(0x21e17812b815b70d, 58, 64), new(0x1a72ec851c80f40c, 58, 64),
        new(0x4afff6d9d2004d20, 58, 64), new(0x454716ca21624902, 58, 64), new(0x281c19a8bbc1e70a, 60, 16),
        new(0x508d4ea1a3408868, 59, 32), new(0x29ff05d41960031c, 57, 128), new(0x1fb9b769c40b0790, 57, 128),
        new(0x7732a4d5f22b8228, 57, 128), new(0x705f74ca9d04c744, 57, 128), new(0x3dd901be44794156, 57, 128),
        new(0x52e2cd2c1f18a14b, 57, 128), new(0x6097ce9e491147cd, 59, 32), new(0x73f77e7ccfa843dd, 61, 8),
        new(0x4009be69585bb673, 60, 16), new(0x6b6901185a6e4ef4, 60, 16), new(0x5edbf52d237a780c, 60, 16),
        new(0x185bebf216503615, 60, 16), new(0x639a81d732f79a0f, 60, 16), new(0x2ac3311bd9fed10b, 60, 16),
        new(0x45c14b432630c919, 61, 8)
    ];
}
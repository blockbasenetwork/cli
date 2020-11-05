# BlockBase CLI
A command-line interface for BlockBase nodes

## Usage

After compiling or downloading a compiled package run the cli with:

```
./blockbasecli
```

To get help with any command run:

```
./blockbasecli <command> --help
```

## Keys

To store a key to be used when executing a query on a requester node use:

```
./blockbasecli savekey -keyname <name_of_the_key> -key <eos_private_key_string>
```
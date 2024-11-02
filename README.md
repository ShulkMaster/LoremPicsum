# Lorem Picsum API wrapper

This is a [Lorem Picsum](https://picsum.photos) wrapper over the public API
that allows you to get the stylish placeholders images either as a URL, save it
into a file or keep the in memory `Stream`.

:sparkles: Features:
 - Allows for requesting:
   - random images 
   - images by id
   - images from a seed
 - Images post process
   - Gray scale
   - Blur
 - Image download
   - jpg
   - webp
 - Pipe the `Stream` into other `Stream`
 - Save the `Stream` into a `File`

## :memo: Usage

### Getting the URL to a random image

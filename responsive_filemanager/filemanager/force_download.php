<?php

$config = include 'config/config.php';


//TODO switch to array
extract($config, EXTR_OVERWRITE);

include 'include/utils.php';

if ($_SESSION['RF']["verify"] != "RESPONSIVEfilemanager")
{
	response(trans('forbiden').AddErrorLocation(), 403)->send();
	
}

include 'include/mime_type_lib.php';

if (
	strpos($_POST['path'], '/') === 0
	|| strpos($_POST['path'], '../') !== false
	|| strpos($_POST['path'], './') === 0
)
{
	response(trans('wrong path'.AddErrorLocation()), 400)->send();
	
}


if (strpos($_POST['name'], '/') !== false)
{
	response(trans('wrong path'.AddErrorLocation()), 400)->send();
	
}

$path = $current_path . $_POST['path'];
$name = $_POST['name'];

$info = pathinfo($name);

if ( ! in_array(fix_strtolower($info['extension']), $ext))
{
	response(trans('wrong extension'.AddErrorLocation()), 400)->send();
	
}

if ( ! file_exists($path . $name))
{
	response(trans('File_Not_Found'.AddErrorLocation()), 404)->send();
	
}

$file_name  = $info['basename'];
$file_ext   = $info['extension'];
$file_path  = $path . $name;

// make sure the file exists
if (is_file($file_path) && is_readable($file_path))
{

    $size = filesize($file_path);
    $file_name = rawurldecode($file_name);
    $mime_type = get_file_mime_type($file_path);

    @ob_end_clean();
    if(ini_get('zlib.output_compression'))
    ini_set('zlib.output_compression', 'Off');
    header('Content-Type: ' . $mime_type);
    header('Content-Disposition: attachment; filename="'.$file_name.'"');
    header("Content-Transfer-Encoding: binary");
    header('Accept-Ranges: bytes');

    if(isset($_SERVER['HTTP_RANGE']))
    {
        list($a, $range) = explode("=",$_SERVER['HTTP_RANGE'],2);
        list($range) = explode(",",$range,2);
        list($range, $range_end) = explode("-", $range);
        $range=intval($range);
        if(!$range_end) {
            $range_end=$size-1;
        } else {
            $range_end=intval($range_end);
        }

        $new_length = $range_end-$range+1;
        header("HTTP/1.1 206 Partial Content");
        header("Content-Length: $new_length");
        header("Content-Range: bytes $range-$range_end/$size");
    } else {
        $new_length=$size;
        header("Content-Length: ".$size);
    }

    $chunksize = 1*(1024*1024);
    $bytes_send = 0;
    if ($file = fopen($file_path, 'r'))
    {
        if(isset($_SERVER['HTTP_RANGE']))
        fseek($file, $range);

        while(!feof($file) &&
            (!connection_aborted()) &&
            ($bytes_send<$new_length)
        )
        {
            $buffer = fread($file, $chunksize);
            echo($buffer);
            flush();
            $bytes_send += strlen($buffer);
        }
        fclose($file);
    } else {
        die('Error - can not open file.');
    }

    die();

}
else
{
	// file does not exist
	header("HTTP/1.0 404 Not Found");
	
}


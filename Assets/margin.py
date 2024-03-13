import os

def remove_meta_files(path):
  """
  Removes all files ending with .meta in the given path and its subdirectories.

  Args:
    path: The directory path to search for files.
  """
  for filename in os.listdir(path):
    if filename.endswith(".meta"):
      file_path = os.path.join(path, filename)
      os.remove(file_path)
      print(f"Deleted: {file_path}")
    elif os.path.isdir(os.path.join(path, filename)):
      remove_meta_files(os.path.join(path, filename))

# Start searching from the current working directory
current_dir = os.getcwd()
remove_meta_files(current_dir)

print("Finished removing .meta files.")

from base64 import b64decode

def hamming_distance(bytes1, bytes2):
  assert len(bytes1) == len(bytes2)

  distance = 0
  for zipped_bytes in zip(bytes1, bytes2):
    x = zipped_bytes[0] ^ zipped_bytes[1]

    set_bits = 0
    while (x > 0):
      set_bits += x & 1;
      x >>= 1;
    distance += set_bits

  return distance



def get_keylength(ciphertext):
  lowest = None
  best_keylength = None

  for keylength in range(2, 41):
    to_average = []

    start = 0
    end = start + keylength
    while (1):
      first_chunk = ciphertext[start:end]
      second_chunk = ciphertext[start + keylength:end + keylength]
      if (len(second_chunk) < keylength):
          break

      distance = hamming_distance(first_chunk, second_chunk)

      normalized = distance / keylength

      to_average.append(normalized)

      start = end + keylength
      end = start + keylength

    average = sum(to_average) / len(to_average)
    to_average = []


    if lowest == None or average < lowest:
      lowest = average
      best_keylength = keylength

  return best_keylength

def transpose_chunks_by_keylength(keylength, ciphertext):

  chunks = dict.fromkeys(range(keylength))

  i = 0
  for octet in ciphertext:

    if (i == keylength): i = 0
    if (chunks[i] == None): chunks[i] = []
    chunks[i].append(octet)

    i += 1

  return chunks


def get_key(blocks):
  common = 'TAOIN SHRDLU'
  key = ''

  for i in blocks:
    current_high_score = 0
    current_key_char = ''

    for j in range(127):
      # Create an array of all the XOR'd
      x = [j ^ the_bytes for the_bytes in blocks[i]]

      # Convert the array of numbers back into bytes
      b = bytes(x)
      b_str = str(b, 'utf-8')
      score = 0
      for k in b_str.upper():
        if k in common:
          score += 1

      if score > current_high_score:
        current_high_score = score
        current_key_char = chr(j)

    key += current_key_char

  return key


def decrypt(message_bytes, key):
  decrypted = b''

  i = 0
  for byte in message_bytes:
    if (i == len(key)):
      i = 0
    xor = byte ^ ord(key[i])
    decrypted += bytes([xor])

    i += 1

  return decrypted

if __name__ =="__main__":
  decoded = b64decode("G0IFOFVMLRAPI1QJbEQDbFEYOFEPJxAfI10JbEMFIUAAKRAfOVIfOFkYOUQFI15ML1kcJFUeYhA4IxAeKVQZL1VMOFgJbFMDIUAAKUgFOElMI1ZMOFgFPxADIlVMO1VMO1kAIBAZP1VMI14ANRAZPEAJPlMNP1VMIFUYOFUePxxMP19MOFgJbFsJNUMcLVMJbFkfbF8CIElMfgZNbGQDbFcJOBAYJFkfbF8CKRAeJVcEOBANOUQDIVEYJVMNIFwVbEkDORAbJVwAbEAeI1INLlwVbF4JKVRMOF9MOUMJbEMDIVVMP18eOBADKhALKV4JOFkPbFEAK18eJUQEIRBEO1gFL1hMO18eJ1UIbEQEKRAOKUMYbFwNP0RMNVUNPhlAbEMFIUUALUQJKBANIl4JLVwFIldMI0JMK0INKFkJIkRMKFUfL1UCOB5MH1UeJV8ZP1wVYBAbPlkYKRAFOBAeJVcEOBACI0dAbEkDORAbJVwAbF4JKVRMJURMOF9MKFUPJUAEKUJMOFgJbF4JNERMI14JbFEfbEcJIFxCbHIJLUJMJV5MIVkCKBxMOFgJPlVLPxACIxAfPFEPKUNCbDoEOEQcPwpDY1QDL0NCK18DK1wJYlMDIR8II1MZIVUCOB8IYwEkFQcoIB1ZJUQ1CAMvE1cHOVUuOkYuCkA4eHMJL3c8JWJffHIfDWIAGEA9Y1UIJURTOUMccUMELUIFIlc=")

  chunks = transpose_chunks_by_keylength(18,decoded)
  key = get_key(chunks)
  result = decrypt(decoded, "L0l")
  result1 = get_keylength(decoded)
  print(key)

from Crypto.Util.number import *
import random
import sys
ar=int(sys.argv[1])
q=getPrime(ar)
print(q)
""" im=int(sys.argv[2])
while True:
       k= random.randint(2**im,2**(im+1))
       if isPrime(k*q+1):
            print(q,(k*q+1))
            break """

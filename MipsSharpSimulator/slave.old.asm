	.data
	
VetorA: .word 0,0,0,0,0,0
MatrizB:.word 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0
VetorC: .word 0,0,0,0,0,0
	.text
	.globl main
	
main:	
        li $s0, 0
        li $s1, 6
        la $t0, VetorA
        la $t1, MatrizB
        la $t2, VetorC        
        
recebeA: rcv $s3, 24, $t0

recebeB: rcv $s3, 144, $t1
		li $a0, 0
		li $s2, 0
		li $a1, 6
		li $s3, 6
		li $t4, 0
	    addi, $t3, $t1, 0
	    addi, $t4, $t0, 0


proxCol: addi $t5, $t3, 0

soma:   
		lw $a2, 0($t3)
		lw $a3, 0($t4)
		mult $t6, $a2, $a3

		lw $a2, 0($t2)
		add $a2, $t6, $a2
		sw $a2, 0($t2)
		addi $a0, $a0, 1
		addi $t3, $t3, 24
		addi $t4, $t4, 4
		bne $a0, $a1, soma

		li $a0, 0
		addi $t4, $t0, 0
		addi $t3, $t5, 4 
		addi $t2, $t2, 4
		addi $s2, $s2, 1
		bne $s2, $s3, proxCol	
	
enviaA: snd $s0, 24, $t2                






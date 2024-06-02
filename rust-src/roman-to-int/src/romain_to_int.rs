pub mod romain_to_int {
    pub fn romain_to_int(x: u32, y: u32) -> u32 {
        x + y
    }
}

#[cfg(test)]
mod tests {
    use crate::romain_to_int::romain_to_int::romain_to_int;

	#[test]
	fn four() {
		assert_eq!(4, romain_to_int(2, 2));
	}

	#[test]
	fn eight() {
		assert_eq!(8, romain_to_int(5, 3));
	}
}

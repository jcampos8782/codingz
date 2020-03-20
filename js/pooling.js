const MAX_CANCER_PER_POOL = 4;
const MIN_CANCER_PER_POOL = 2;
const MAX_SAMPLES_PER_POOL = 8;

let poolSamples = (samples) => {
  // The minimum number of pools is determined by how many samples exist.
  let poolCount = Math.ceil(samples.length / MAX_SAMPLES_PER_POOL);

  // barcode -> count for barcode
  let sampleCount = {};
  let cancerCount = 0;

  // Iterate over each sample and keep track of how many times we see each
  // and which are cancerous vs healthy.
  for(let i = 0; i < samples.length; i++) {
    let sample = samples[i];
    if (sampleCount[sample.barcode] === undefined) {
      sampleCount[sample.barcode] = 0;
    }
    sampleCount[sample.barcode]++;

    // If we have more of a certain barcode than our current pool count,
    // increase the pool count
    if (sampleCount[sample.barcode] > poolCount) {
      poolCount = sampleCount[sample.barcode];
    }

    if (sample.type === 'cancer') {
      cancerCount++;
    }
  }

  // Ensure that we can put at least MIN_CANCER_PER_POOL in each pool
  if (cancerCount / poolCount < MIN_CANCER_PER_POOL) {
    throw "Cannot process batch."
  }

  // If the count for cancerous samples exceeds the maximum for a pool, increase
  // the number of pools until it is within bounds
  while(Math.ceil(cancerCount / poolCount) > MAX_CANCER_PER_POOL) {
    poolCount++;
  }

  // Sort by count
  let sorted = samples.sort((a,b) => sampleCount[b.barcode] - sampleCount[a.barcode]);

  // Queue up items that we will force into open buckets later due to constraint violations
  let retries = [];

  // Now fill the pools sequentially to ensure evenness.
  let pools = Array.from({length: poolCount}, () => []);
  let cancerSamplesPerPool = Array.from({length: pools.length}, () => 0);

  for(let i = 0; i < sorted.length; i++) {
    let poolId = i % poolCount;
    let sample = sorted[i];

    if (sample.type === 'cancer') {
      // If this pool already has maximum number of cancer samples, come back to it later
      if (cancerSamplesPerPool[poolId] === MAX_CANCER_PER_POOL) {
        retries.push(sample);
        continue;
      }
      cancerSamplesPerPool[poolId]++;
    }

    pools[poolId].push(sample);
  }

  // Each retry should go into the first pool which has capacity for cancer samples which does not already
  // contain this barcode. Note that retries are already guaranteed to be sorted by barcode!
  for(let i = 0; i < retries.length; i++) {
    let sample = retries[i];

    // try every pool
    for(let j = 0; j < poolCount; j++) {
      if (cancerSamplesPerPool[j] === MAX_CANCER_PER_POOL) {
        continue;
      }

      // If any have the same barcode, move on
      if (pools[j].find(s => s.barcode === sample.barcode)) {
        continue;
      }

      // We found an acceptable pool!
      pools[j].push(sample);
      cancerSamplesPerPool[j]++;
      break;
    }
  }

  return pools;
}

poolSamples(s);
